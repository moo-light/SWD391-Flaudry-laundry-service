using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class UserController : BaseController, IWebController<BaseUser>
    {
        private readonly ICustomerService _userService;

        public UserController(ICustomerService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task RegisterAsync(UserRegisterDTO registerObject) => await _userService.RegisterAsync(registerObject);
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO loginObject) => await _userService.LoginAsync(loginObject);
        [HttpPost]
        public async Task<IActionResult> Add(BaseUser entity)
        {
            var result = await _userService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public IActionResult Update(BaseUser entity)
        {
            var result = _userService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin,Customer,Driver")]
        public async Task<IActionResult> GetByIDAsync(Guid Id)
        {
            var result = await _userService.GetByIdAsync(Id);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            var result = _userService.Remove(Id);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var result = await _userService.GetCountAsync();
            return result>0 ? Ok(result) : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetListWithFilter(UserFilteringModel entity)
        {
            var result = await _userService.GetFilterAsync(entity);
            return result != null? Ok(result) : BadRequest();
        }

    }
}