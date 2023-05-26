using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;

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
        public async Task<string> LoginAsync(UserLoginDTO loginObject) => await _userService.LoginAsync(loginObject);

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
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _userService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]

        public IActionResult DeleteById(Guid entityId)
        {
            var result = _userService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }

        //[HttpGet]


    }
}