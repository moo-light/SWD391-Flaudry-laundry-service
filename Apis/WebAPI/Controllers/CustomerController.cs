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

namespace WebAPI.Controllers
{
    public class CustomerController : BaseController, IWebController<Customer>
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
        public async Task<IActionResult> Update(Guid id, CustomerRequestDTO entity)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await _customerService.UpdateAsync(id, entity);
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
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result =await _customerService.RemoveAsync(id);
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

        private bool Exist(Guid id)
        {
            var customer = _customerService.GetByIdAsync(id);
            if (customer == null) return false;
            return true;
        }
    }
}