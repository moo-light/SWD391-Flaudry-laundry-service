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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Eventing.Reader;

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
        [Authorize(Roles = "Admin")]
        public async Task<Pagination<CustomerFilteringModel>> GetAllAsync(int pageIndex = 0, int pageSize = 10)
        {
            var o = _unitOfWork.CustomerRepository.ToPagination(pageIndex, pageSize);
            return _mapper.Map<Pagination<CustomerFilteringModel>>(o);
        }
        [Authorize(Roles = "Admin,Customer,Driver")]
        public async Task<Customer?> GetByIdAsync(Guid entityId) => await _unitOfWork.CustomerRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Customer user)
        {
            await _unitOfWork.CustomerRepository.AddAsync(user);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.CustomerRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Customer entity)
        {
            _unitOfWork.CustomerRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordHash(userObject.Email, userObject.Password);
            return new UserLoginDTOResponse
            {
                UserId = user.Id,
                JWT = user.GenerateJsonWebToken(_configuration.JWTSecretKey, _currentTime.GetCurrentTime())
            };
        }
        public async Task<bool> CheckEmail(CustomerRegisterDTO userObject)
        {
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(userObject.Email);
            if (isExited)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> RegisterAsync(CustomerRegisterDTO customer)
        {

            var newCustomer = _mapper.Map<Customer>(customer);

            await _unitOfWork.UserRepository.AddAsync(newCustomer);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public async Task<Pagination<CustomerFilteringModel>> GetFilterAsync(CustomerFilteringModel user)
        {
            var o = _unitOfWork.CustomerRepository.GetFilter(user).ToList();
            return _mapper.Map<Pagination<CustomerFilteringModel>>(o);
        }

        public UserLoginDTOResponse LoginAdmin(UserLoginDTO loginObject)
        {
            if (loginObject.Email.CheckPassword(_configuration.AdminAccount.Email))
                if (loginObject.Password.CheckPassword(_configuration.AdminAccount.Password))
                {
                    return new UserLoginDTOResponse
                    {
                        UserId = Guid.NewGuid(),
                        JWT = new BaseUser()
                        {
                            IsAdmin = true,
                            Email = _configuration.AdminAccount.Email,
                            Id = Guid.NewGuid()//admin want to be anonymous
                        }.GenerateJsonWebToken(_configuration.JWTSecretKey, _currentTime.GetCurrentTime())
                    };
                }
            throw new EventLogInvalidDataException("Warning after 5 more tries this page will be disabled");
        }
    }
}
