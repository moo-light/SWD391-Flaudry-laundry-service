using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class ServiceController : BaseController, IWebController<Service>
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        [HttpPost]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Add(Service entity)
        {
            var result = await _serviceService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Update(Service entity)
        {
            var result = _serviceService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _serviceService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _serviceService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _serviceService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _serviceService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            var result = await _serviceService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}