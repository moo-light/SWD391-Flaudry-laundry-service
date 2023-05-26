﻿using Application;
using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _unitOfWork.UserRepository.GetAllAsync();
        public async Task<User?> GetByIdAsync(Guid entityId) => await _unitOfWork.UserRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(User newUser) => await _unitOfWork.UserRepository.AddAsync(newUser);
        public bool Remove(Guid entityId) => _unitOfWork.UserRepository.SoftRemoveByID(entityId);
        public bool Update(User entity) => _unitOfWork.UserRepository.Update(entity);
        public async Task<string> LoginAsync(UserLoginDTO userObject)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUserNameAndPasswordHash(userObject.UserName, userObject.Password.Hash());
            return user.GenerateJsonWebToken(_configuration.JWTSecretKey, _currentTime.GetCurrentTime());
        }

        public async Task RegisterAsync(UserRegisterDTO userObject)
        {
            // check username exited
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(userObject.Email);

            if (isExited)
            {
                throw new Exception("Username exited please try again");
            }

            var newUser = new User
            {
                Email = userObject.Email,
                PasswordHash = userObject.Password.Hash(),
                Address = userObject.Address
            };

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangeAsync();
        }

    }
}
