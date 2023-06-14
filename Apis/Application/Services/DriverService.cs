using Application;
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
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        public DriverService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Driver>> GetAllAsync() => await _unitOfWork.DriverRepository.GetAllAsync();
        public async Task<Driver?> GetByIdAsync(Guid entityId) => await _unitOfWork.DriverRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Driver user)
        {
            await _unitOfWork.DriverRepository.AddAsync(user);
            return await _unitOfWork.SaveChangeAsync() >0;
        }

        public bool Remove(Guid entityId)
        {
             _unitOfWork.DriverRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Driver entity)
        {
             _unitOfWork.DriverRepository.Update(entity);
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

        public async Task RegisterAsync(UserRegisterDTO driver)
        {
            // check username exited
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(driver.Email);

            if (isExited)
            {
                throw new InvalidDataException("Username exited please try again");
            }

            var newUser = new Driver
            {
                Email = driver.Email,
                PasswordHash = driver.Password.Hash(),
            };

            await _unitOfWork.DriverRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Driver>> GetFilterAsync(UserFilteringModel driver)
        {
            return  _unitOfWork.DriverRepository.GetFilter(driver);
        }
    }
}
