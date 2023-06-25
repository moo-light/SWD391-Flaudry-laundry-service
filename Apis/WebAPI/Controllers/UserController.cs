using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.ViewModels.FilterModels;

namespace WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IBaseUserService _userService;

        public UserController(IBaseUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO loginObject)
        {
            return await _userService.LoginAsync(loginObject);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIDAsync(Guid Id)
        {
            var result = await _userService.GetByIdAsync(Id);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _userService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
            return result != null ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListWithFilter(DriverFilteringModel? entity)
        {
            var result = await _userService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest(result);
        }

    }
}