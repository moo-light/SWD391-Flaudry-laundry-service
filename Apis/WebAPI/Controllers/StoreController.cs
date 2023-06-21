using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Application.ViewModels.FilterModels;

namespace WebAPI.Controllers
{
    public class StoreController : BaseController, IWebController<Store>
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

    
        [HttpPost]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Add(Store entity)
        {
            var result = await _storeService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]

        [Authorize(Roles = "Customer,Admin")]
        public IActionResult Update(Store entity)
        {
            var result = _storeService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _storeService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles = "Customer,Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _storeService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _storeService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCount()
        {
            var result = await _storeService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetListWithFilter(StoreFilteringModel? entity)
        {
            var result = await _storeService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}