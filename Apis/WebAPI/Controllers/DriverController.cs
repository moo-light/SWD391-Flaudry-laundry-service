using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.ViewModels.FilterModels;

namespace WebAPI.Controllers
{
    public class DriverController : BaseController, IWebController<Driver>
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task RegisterAsync(DriverRegisterDTO registerObject) => await _driverService.RegisterAsync(registerObject);
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add(Driver entity)
        {
            var result = await _driverService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Authorize(Roles ="Admin,Driver")]
        public IActionResult Update(Driver entity)
        {
            var result = _driverService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin,Driver")]
        public async Task<IActionResult> GetByIDAsync(Guid id)
        {
            var result = await _driverService.GetByIdAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin,Driver")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _driverService.Remove(id);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _driverService.GetCountAsync();
            return result>0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListWithFilter(DriverFilteringModel? entity)
        {
            var result = await _driverService.GetFilterAsync(entity);
            return result != null? Ok(result) : BadRequest();
        }

    }
}