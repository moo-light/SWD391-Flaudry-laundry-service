using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;

namespace WebAPI.Controllers
{
    public class UserController : BaseController, IWebController<User>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task RegisterAsync(UserRegisterDTO registerObject) => await _userService.RegisterAsync(registerObject);
        [HttpPost]
        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO loginObject) => await _userService.LoginAsync(loginObject);
        [HttpPost]
        public async Task<IActionResult> AddAsync(User entity)
        {
            var result = await _userService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public IActionResult Update(User entity)
        {
            var result = _userService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{id}")]
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

        public async Task<IActionResult> GetListWithFilter(User entity)
        {
            var result = await _userService.GetFilter(entity);
            return result != null? Ok(result) : BadRequest();
        }
    }
}