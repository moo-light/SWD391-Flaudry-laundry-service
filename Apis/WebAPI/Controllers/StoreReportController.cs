using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;
using Application.ViewModels;

namespace WebAPI.Controllers
{
    public class StoreReportController : BaseController, IWebController<StoreReport>
    {
        private readonly IStoreReportService _storeReportService;

        public StoreReportController(IStoreReportService storeReportService)
        {
            _storeReportService = storeReportService;
        }

    
        [HttpPost]
        public async Task<IActionResult> Add(StoreReport entity)
        {
            var result = await _storeReportService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]

        public IActionResult Update(StoreReport entity)
        {
            var result = _storeReportService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _storeReportService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]

        public IActionResult DeleteById(Guid entityId)
        {
            var result = _storeReportService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _storeReportService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var result = await _storeReportService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            IEnumerable<StoreReport> result = await _storeReportService.GetFilter(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}