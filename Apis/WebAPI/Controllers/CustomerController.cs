using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.ViewModels.FilterModels;
using Application.ViewModels.Customer;
using Microsoft.IdentityModel.Tokens;
using Application.ViewModels.UserViewModels;

namespace WebAPI.Controllers
{
    public class CustomerController : BaseController, IWebController<Customer>
    {
        private readonly ICustomerService _customerService;
        private readonly IBaseUserService _userService;

        public CustomerController(ICustomerService customerService, IBaseUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task RegisterAsync(CustomerRegisterDTO registerObject) => await _customerService.RegisterAsync(registerObject);
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(CustomerRequestDTO entity)
        {
            var result = await _customerService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Update(Guid id, CustomerRequestUpdateDTO entity)
        {
            var exist = await ExistCustomer(id);
            if (!exist) return NotFound();
            bool result;
            if (HttpContext.User.Claims.Any(x => x.Type.Contains("role") && x.Value.Equals("Admin",StringComparison.OrdinalIgnoreCase)))
            {
                result = await _customerService.UpdateAsync(id, entity);
            }
            else
            {
                var user = new UserLoginDTO()
                {
                    Email = entity.LoginEmail,
                    Password = entity.OldPassword
                };
                if (await _userService.LoginAsync(user) != null)
                    result = await _customerService.UpdateAsync(id, entity);
                else return BadRequest();
            }
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid id)
        {
            var result = await _customerService.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _customerService.GetAllAsync();
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var exist = await ExistCustomer(id);
            if (!exist) return NotFound();
            var result = await _customerService.RemoveAsync(id);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _customerService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListWithFilter(CustomerFilteringModel? entity)
        {
            var result = await _customerService.GetFilterAsync(entity);
            return result.IsNullOrEmpty() ? BadRequest() : Ok(result);
        }

        private async Task<bool> ExistCustomer(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return false;
            return true;
        }
    }
}