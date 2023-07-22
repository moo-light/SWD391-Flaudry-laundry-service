using Application.ViewModels.FilterModels;
using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Application.ViewModels.Batchs;
using Microsoft.IdentityModel.Tokens;
using Application.ViewModels.Customer;
using Application.Interfaces;
using Domain.Enums;
using Application.Utils;

namespace WebAPI.Controllers
{
    public class BatchController : BaseController, IWebController<Batch>
    {
        private readonly IBatchService _batchService;
        private readonly IClaimsService _claimsService;
        public BatchController(IBatchService batchService, IClaimsService claimsService)
        {
            _batchService = batchService;
            _claimsService = claimsService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Driver")]
        public async Task<IActionResult> Add(BatchRequestDTO_V2 batchRequestDTO, string? driverId = default)
        {
            if (driverId != null && _claimsService.GetCurrentUserRole != "Admin") return Forbid();
            if (driverId == null && _claimsService.GetCurrentUserRole != "Driver") return BadRequest(new
            {
                Message = "Please input DriverId"
            });
            Guid.TryParse(driverId, out Guid driverGUID);

            var result = await _batchService.AddAsync(batchRequestDTO, driverGUID == Guid.Empty ? null : driverGUID);
            return result ? Ok(new
            {
                message = "Add successfully"
            }) : BadRequest();
        }
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> Update(Guid id, BatchRequestDTO_V2 entity)
        {
            var exist = await ExistBatch(id);
            if (!exist) return NotFound();
            bool result;

            result = await _batchService.Update(id, entity);
            return result ? Ok(new
            {
                message = "Update Successfully"
            }) : BadRequest();
        }
        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles = "Admin,Driver,Customer")]

        public IActionResult DeleteById(Guid entityId)
        {
            var result = _batchService.Remove(entityId);
            return result != null ? Ok(new
            {
                message = "Delete Successfully"
            }) : BadRequest();
        }
        [HttpPatch("{entityId:guid}")]
        [Authorize(Roles = "Admin,Driver")]

        public async Task<IActionResult> FinishBatch(Guid entityId)
        {
            var entity = await _batchService.GetByIdAsync(entityId);

            if (_claimsService.GetCurrentUserRole == "Driver" && entity.Status.IsEnum(BatchStatus.InProgress)
                || _claimsService.GetCurrentUserRole == "Admin")
            {
                entity.Status = nameof(BatchStatus.Completed);
            }
            else
            {
                return Forbid();
            }
            var result = _batchService.SmallUpdate(entity);
            return result ? Ok(new
            {
                message = "Batch Update Successfully"
            }) : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetAllAsync(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _batchService.GetBatchListPagi(pageIndex, pageSize);
            return result.Items.IsNullOrEmpty() ? NotFound() : Ok(result);
        }
        [HttpGet("{entityId:guid}")]
        [Authorize(Roles = "Driver,Customer,Admin")]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _batchService.GetByIdAsync(entityId);
            return (result != null ? Ok(result) : NotFound());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _batchService.GetCountAsync();
            return result > 0 ? Ok(result) : NotFound();
        }
        [HttpPost("{pageIndex?}/{pageSize?}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetListWithFilter(BatchFilteringModel? entity,
                                                    int pageIndex = 0,
                                                    int pageSize = 10)
        {
            var result = await _batchService.GetFilterAsync(entity, pageIndex, pageSize);
            return result.Items.IsNullOrEmpty() ? NotFound() : Ok(result);
        }
        private async Task<bool> ExistBatch(Guid id)
        {
            var customer = await _batchService.GetByIdAsync(id);
            if (customer == null) return false;
            return true;
        }
    }
}
