using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
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
        public async Task<IActionResult> AddAsync(Payment entity)
        {
            var result = await _paymentService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _paymentService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _paymentService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _paymentService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public IActionResult Update(Payment entity)
        {
            var result = _paymentService.Update(entity);
            return result ? Ok() : BadRequest();
        }
    }
}
