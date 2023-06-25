using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels.Customer;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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



        public async Task RegisterAsync(CustomerRegisterDTO customer)
        {
            // check username exited
            var isExited = await _unitOfWork.UserRepository.CheckEmailExisted(customer.Email);

            if (isExited)
            {
                throw new InvalidDataException("Username exited please try again");
            }

            var newCustomer = _mapper.Map<Customer>(customer);

            await _unitOfWork.UserRepository.AddAsync(newCustomer);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.CustomerRepository.GetCountAsync();
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetFilterAsync(CustomerFilteringModel user)
        {
            List<Customer> customers = _unitOfWork.CustomerRepository.GetFilter(user).ToList();
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
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
