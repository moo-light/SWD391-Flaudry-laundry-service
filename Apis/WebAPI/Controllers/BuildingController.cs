using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;

namespace WebAPI.Controllers
{
    public class BuildingController : BaseController, IWebController<Building>
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Building entity)
        {
            var result = await _buildingService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _buildingService.Remove(entityId);
            return result != null ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _buildingService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _buildingService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpPut]
        public IActionResult Update(Building entity)
        {
            var result = _buildingService.Update(entity);
            return result ? Ok() : BadRequest();
        }
    }
}
