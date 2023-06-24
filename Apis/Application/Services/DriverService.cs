using Application;
using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
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
        public async Task<bool> CheckEmail(DriverRegisterDTO driverRegisterDTO)
        {
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(driverRegisterDTO.Email);
            if (isExited)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> RegisterAsync(DriverRegisterDTO driver)
        {
            var newDriver = _mapper.Map<Driver>(driver);

            await _unitOfWork.DriverRepository.AddAsync(newDriver);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public async Task<Pagination<Driver>> GetFilterAsync(DriverFilteringModel driver)
        {
            var o = _unitOfWork.DriverRepository.GetFilter(driver);
            return _mapper.Map<Pagination<Driver>>(o);
        }
    }
}
