using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OrderDetailController : BaseController, IWebController<OrderDetail>
    {
        private readonly IOrderDetail _orderDetailService;
        public OrderDetailController(IOrderDetail packageService)
        {
            _orderDetailService = packageService;
        }
        [HttpPost]
        [Authorize(Roles ="Customer,Admin")]
        public async Task<IActionResult> Add(OrderDetail entity)
        {
            var result = await _orderDetailService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles ="Customer,Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _orderDetailService.Remove(entityId);
            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles ="Customer,Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _orderDetailService.GetAllAsync();
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _orderDetailService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpPut]
        [Authorize(Roles ="Customer,Admin")] // co dieu kien chua gui vao store
        public IActionResult Update(OrderDetail entity)
        {
            var result = _orderDetailService.Update(entity);
            return result ? Ok(result) : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles ="Customer,Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _orderDetailService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize(Roles ="Customer,Admin")]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            var result = await _orderDetailService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
