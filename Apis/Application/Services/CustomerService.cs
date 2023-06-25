using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels.Customer;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<CustomerResponseDTO>> GetAllAsync()
        {
            List<Customer> customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }

        [Authorize(Roles = "Admin,Customer,Driver")]
        public async Task<CustomerResponseDTO?> GetByIdAsync(Guid entityId)
        {
            Customer? customer = await _unitOfWork.CustomerRepository.GetByIdAsync(entityId);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<bool> AddAsync(CustomerRequestDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            if (newCustomer == null) return false;
            if (await _unitOfWork.UserRepository.CheckEmailExisted(newCustomer.Email)) throw new InvalidDataException("Email Exist!");
            await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> RemoveAsync(Guid entityId)
        {
            _unitOfWork.CustomerRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, CustomerRequestDTO entity)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null) return false;
            if (await _unitOfWork.UserRepository.CheckEmailExisted(entity.Email)) throw new InvalidDataException("Email Exist!");
            customer = _mapper.Map(entity, customer);
            _unitOfWork.CustomerRepository.Update(customer);
            return await _unitOfWork.SaveChangeAsync() > 0;
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
            return await _unitOfWork.CustomerRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel user)
        {
            return _unitOfWork.CustomerRepository.GetFilter(user).ToList();
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
        [HttpGet]
        public async Task<Pagination<Customer>> GetCustomerListPagi(int pageIndex = 0, int pageSize = 10)
        {
            var customers = await _unitOfWork.CustomerRepository.ToPagination(pageIndex, pageSize);
            var customerFilteringModels = new Pagination<Customer>
            {
                PageIndex = customers.PageIndex,
                PageSize = customers.PageSize,
                TotalItemsCount = customers.TotalItemsCount,
                Items = customers.Items.Select(c => new Customer
                {
                    FullName = c.FullName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address
                }).ToList()
            };
            return customerFilteringModels;
        }
    }
}
