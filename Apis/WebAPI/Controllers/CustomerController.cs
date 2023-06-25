using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.ViewModels.FilterModels;
using Application.Services;
using Application.Commons;
using Microsoft.IdentityModel.Tokens;
using Application.ViewModels.Customer;

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
        public async Task<IActionResult> RegisterAsync(CustomerRegisterDTO registerObject)
        {
            var checkExist = await _customerService.CheckEmail(registerObject);
            if (checkExist)
            {
                return BadRequest(new
                {
                    Message = "Email has existed, please try again"
                });
            }
            else
            {
                var checkReg = await _customerService.RegisterAsync(registerObject);
                if (checkReg)
                {
                    return Ok(new
                    {
                        Message = "Register Success"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "Register fail"
                    });
                }
            }
        }
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
        [HttpGet]
        public async Task<IActionResult> GetCustomerPagination(int pageIndex, int pageSize)
        {
            var customers = await _customerService.GetCustomerListPagi(pageIndex, pageSize);
            return Ok(customers);
        }

        private bool Exist(Guid id)
        {
            var customer = _customerService.GetByIdAsync(id);
            if (customer == null) return false;
            return true;
        }
    }
}