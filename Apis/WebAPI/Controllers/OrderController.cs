using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Application.Services;
using Application.Interfaces.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebAPI.Controllers
{
    public class OrderController : BaseController, IWebController<LaundryOrder>
    {
        private readonly IOrderService _orderService;
        private readonly IClaimsService _claimsService;

        public OrderController(IOrderService orderService,IClaimsService claimsService)
        {
            _orderService = orderService;
           _claimsService = claimsService;
        }

    
        [HttpPost]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Add(LaundryOrder entity)
        {
            var result = await _orderService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]

        [Authorize(Roles = "Admin")]
        //Customer co the Update voi dieu kien la Chua duoc bo vao Batch
        public IActionResult Update(LaundryOrder entity)
        {
            var result = _orderService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _orderService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{entityId:guid}")]
        [Authorize]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _orderService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _orderService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _orderService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            var result = await _orderService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}