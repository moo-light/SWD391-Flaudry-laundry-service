using Application.Commons;
using Application.ViewModels.FilterModels;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels.Customer;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Eventing.Reader;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        private readonly string _jwtSecretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public CustomerService(string jwtSecretKey, string issuer, string audience)
        {
            _jwtSecretKey = jwtSecretKey;
            _issuer = issuer;
            _audience = audience;
        }

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }
        public async Task<IEnumerable<CustomerResponseDTO>> GetAllAsync()
        {
            List<Customer> customers = await _unitOfWork.CustomerRepository.GetAllAsync(x => x.Feedbacks, x => x.Orders);
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }

        public async Task<Customer?> GetByIdAsync(Guid entityId)
        {
            Customer? customer = await _unitOfWork.CustomerRepository.GetByIdAsync(entityId);
            return customer;
        }

        public async Task<bool> AddAsync(CustomerRequestDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            if (newCustomer == null) return false;
            if (await _unitOfWork.UserRepository.CheckEmailExisted(newCustomer.Email)) throw new InvalidDataException("Email Exist!");
            await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAsync(Guid entityId)
        {
            _unitOfWork.CustomerRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, CustomerRequestUpdateDTO entity)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer.Email != entity.Email)
            {
                if (await _unitOfWork.UserRepository.CheckEmailExisted(entity.Email)) throw new InvalidDataException("Email Exist!");
            }

            if (entity.FullName == null) entity.FullName = customer.FullName;
            if (entity.Email == null) entity.Email = customer.Email;
            if (entity.Address == null) entity.Address = customer.Address;
            if (entity.PhoneNumber == null) entity.PhoneNumber = customer.PhoneNumber;

            customer = _mapper.Map(entity, customer);
            _unitOfWork.CustomerRepository.Update(customer);
            return await _unitOfWork.SaveChangesAsync() > 0;
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
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.CustomerRepository.GetCountAsync();
        }

        public async Task<Pagination<CustomerResponseDTO>> GetFilterAsync(CustomerFilteringModel customer, int pageIndex, int pageSize)
        {
            var query = _unitOfWork.CustomerRepository.GetFilter(customer);
            var customers = query.Where(c => c.IsDeleted == false).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var pagination = new Pagination<Customer>()
            {
                TotalItemsCount = query.Where(c => c.IsDeleted == false).Count(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = customers,
            };
            return _mapper.Map<Pagination<CustomerResponseDTO>>(pagination);
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
        public async Task<Pagination<CustomerResponseDTO>> GetCustomerListPagi(int pageIndex = 0, int pageSize = 10)
        {
            var customers = await _unitOfWork.CustomerRepository.ToPagination(pageIndex, pageSize);
            return _mapper.Map<Pagination<CustomerResponseDTO>>(customers);
        }

        public async Task<string> RefreshAdminToken(string refreshToken)
        {
            try
            {
                var claimsPrincipal = ValidateRefreshToken(refreshToken);

                var adminAccount = claimsPrincipal.FindFirstValue(JwtRegisteredClaimNames.Sub);

                var newAccessToken = GenerateAccessToken(adminAccount);

                return newAccessToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to refresh admin token.", ex);
            }
        }
        private ClaimsPrincipal ValidateRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                // Set your validation parameters here
            };

            SecurityToken validatedToken;
            ClaimsPrincipal claimsPrincipal;

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid refresh token.", ex);
            }

            if (claimsPrincipal == null)
            {
                throw new Exception("Invalid refresh token.");
            }

            return claimsPrincipal;
        }

        private string GenerateAccessToken(string adminAccount)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, adminAccount),
                // Add any additional claims as needed
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Set the access token expiration time (e.g., 30 minutes)
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecretKey)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
