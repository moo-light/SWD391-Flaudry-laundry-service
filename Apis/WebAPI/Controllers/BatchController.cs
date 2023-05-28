using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddAsync(Batch entity)
        {
            var result = await _batchService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _batchService.Remove(entityId);
            return result != null ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _batchService.GetAllAsync();
            return result.Count() >= 0 ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _batchService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpPut]
        public IActionResult Update(Batch entity)
        {
            var result = _batchService.Update(entity);
            return result ? Ok() : BadRequest();
        }
    }
}
