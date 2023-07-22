using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels.Drivers;
using Application.ViewModels.StoreManagers;
using Application.ViewModels.Stores;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class StoreManagementController : BaseController
    {
        private readonly IStoreManagementService _storeManagementService;

        public StoreManagementController(IStoreManagementService driverService)
        {
            _storeManagementService = driverService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(StoreManagerRegisterDTO registerObject)
        {
            var checkExist = await _storeManagementService.CheckEmail(registerObject);
            if (checkExist)
            {
                return BadRequest(new
                {
                    Message = "Email has existed, please try again"
                });
            }
            else
            {
                var checkReg = await _storeManagementService.RegisterAsync(registerObject);
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
        public async Task<IActionResult> Add(StoreManagerRequestDTO entity)
        {
            var result = await _storeManagementService.AddAsync(entity);
            return result ? Ok(new
            {
                message = "Add Successfully"
            }) : BadRequest();
        }
    }
}
