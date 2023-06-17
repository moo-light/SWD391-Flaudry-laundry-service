using Application.Interfaces.Services;
using Application.Services;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PaymentController : BaseController, IWebController<Payment>
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add(Payment entity)
        {
            var result = await _paymentService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Payment entity)
        {
            var result = _paymentService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{entityId:guid}")]
        [Authorize(Roles ="Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _paymentService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _paymentService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{entityId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _paymentService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _paymentService.GetCountAsync();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel? entity)
        {
            IEnumerable<Payment> result = await _paymentService.GetFilterAsync(entity);
            return result != null ? Ok(result) : BadRequest();
        }

      
    }
}
