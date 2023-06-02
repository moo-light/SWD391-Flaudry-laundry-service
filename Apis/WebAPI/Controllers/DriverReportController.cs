using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class DriverReportController : BaseController, IWebController<DriverReport>
    {
        private readonly IDriverReportService _driverReportService;
        public DriverReportController(IDriverReportService driverReportService)
        {
            _driverReportService = driverReportService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(DriverReport entity)
        {
            var result = await _driverReportService.AddAsync(entity);
            return result ? Ok(result) : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _driverReportService.Remove(entityId);
            return result != null ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _driverReportService.GetAllAsync();
            return result != null ? Ok(result): BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _driverReportService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpGet]
        public async Task<IActionResult> GetCount()
        {
            var result = await _driverReportService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            var result = await _driverReportService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(DriverReport entity)
        {
            var result = _driverReportService.Update(entity);
            return result ? Ok() : BadRequest();
        }
    }
}
