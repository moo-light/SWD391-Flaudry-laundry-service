using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Domain.Enums;

namespace WebAPI.Controllers
{
    public class OrderInBatchController : BaseController, IWebController<OrderInBatch>
    {
        private readonly IOrderInBatchService _orderInBatchService;

        public OrderInBatchController(IOrderInBatchService orderInBatchService)
        {
            _orderInBatchService = orderInBatchService;
        }

    
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(OrderInBatch entity)
        {
            var result = await _orderInBatchService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]//bao cho admin neu admin approve thi doi
        //cai gi kho de frontend lo
        public IActionResult Update(OrderInBatch entity)
        {
            var result = _orderInBatchService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _orderInBatchService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Driver,Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _orderInBatchService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _orderInBatchService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _orderInBatchService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Driver,Admin")]

        //1. status = RequestChange

        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel? entity)
        {
            var result = await _orderInBatchService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
        [HttpPut("{orderInBatchId:guid}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> RequestUpdateOrderInBatch(Guid orderInBatchId)
        {
            var orderInBatch = await _orderInBatchService.GetByIdAsync(orderInBatchId);

            if (orderInBatch == null) throw new InvalidDataException("Id not Found");
            
            orderInBatch.Status = nameof(OrderInBatchStatus.RequestChange);
            var result = _orderInBatchService.Update(orderInBatch);
            return result ? Ok(result):BadRequest();
        }
    }
}