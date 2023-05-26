using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebAPI.Controllers
{
  public class UserController : BaseController,IWebController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task RegisterAsync(UserLoginDTO loginObject) => await _userService.RegisterAsync(loginObject);

        [HttpPost]
        public async Task<string> LoginAsync(UserLoginDTO loginObject) => await _userService.LoginAsync(loginObject);

        //[HttpGet]


    }
}