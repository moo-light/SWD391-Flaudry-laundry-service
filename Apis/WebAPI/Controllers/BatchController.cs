using Application.ViewModels.FilterModels;
using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Controllers
{
    public class BatchController : BaseController, IWebController<Batch>
    {
        private readonly IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpPost]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> Add(Batch entity)
        {
            var result = await _batchService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles = "Admin,Driver,Customer")]

        public IActionResult DeleteById(Guid entityId)
        {
            var result = _batchService.Remove(entityId);
            return result != null ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _batchService.GetAllAsync();
            return result.Count() >= 0 ? Ok() : BadRequest();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize(Roles = "Driver,Customer,Admin")]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _batchService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpPut]
        [Authorize(Roles = "Driver,Admin")]
        public IActionResult Update(Batch entity)
        {
            var result = _batchService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _batchService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetListWithFilter([AllowNull] BatchFilteringModel? entity)
        {
            var result = await _batchService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
