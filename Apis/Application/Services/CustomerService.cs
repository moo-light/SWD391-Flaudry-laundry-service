﻿using Application;
using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<IEnumerable<BaseUser>> GetAllAsync() => await _unitOfWork.UserRepository.GetAllAsync();
        public async Task<BaseUser?> GetByIdAsync(Guid entityId) => await _unitOfWork.UserRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(BaseUser user)
        {
            await _unitOfWork.UserRepository.AddAsync(user);
            return await _unitOfWork.SaveChangeAsync() >0;
        }

        public bool Remove(Guid entityId)
        {
             _unitOfWork.UserRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(BaseUser entity)
        {
             _unitOfWork.UserRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordHash(userObject.Email, userObject.Password.Hash());
            return new UserLoginDTOResponse
            {
                UserId = user.Id,
                JWT = user.GenerateJsonWebToken(_configuration.JWTSecretKey, _currentTime.GetCurrentTime())
            };
    }

        public async Task RegisterAsync(UserRegisterDTO customer)
        {
            // check username exited
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(customer.Email);

            if (isExited)
            {
                throw new InvalidDataException("Username exited please try again");
            }

            var newUser = new Customer
            {
                Email = customer.Email,
                PasswordHash = customer.Password.Hash(),
                Address = customer.Address
            };

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public async Task<IEnumerable<BaseUser>> GetFilterAsync(UserFilteringModel user)
        {
            return  _unitOfWork.UserRepository.GetFilter(user);
        }
    }
}