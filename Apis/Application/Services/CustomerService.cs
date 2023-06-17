﻿using Application;
using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _unitOfWork.CustomerRepository.GetAllAsync();
        [Authorize(Roles = "Admin,Customer,Driver")]
        public async Task<Customer?> GetByIdAsync(Guid entityId) => await _unitOfWork.CustomerRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Customer user)
        {
            await _unitOfWork.CustomerRepository.AddAsync(user);
            return await _unitOfWork.SaveChangeAsync() >0;
        }

        public bool Remove(Guid entityId)
        {
             _unitOfWork.CustomerRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Customer entity)
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

        public async Task<bool> RegisterAsync(UserRegisterDTO customer)
        {
            // check username exited
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(customer.Email);

            if (isExited)
            {
                throw new Exception("Username exited please try again");
            }

            var newUser = new Customer
            {
                Email = customer.Email,
                PasswordHash = customer.Password.Hash(),
                Address = customer.Address
            };

            await _unitOfWork.UserRepository.AddAsync(newUser);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Customer>> GetFilterAsync(UserFilteringModel user)
        {
            return  _unitOfWork.CustomerRepository.GetFilter(user);
        }
    }
}
