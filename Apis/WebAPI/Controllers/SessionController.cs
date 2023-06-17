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
    public class SessionController : BaseController, IWebController<Session>
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(Session entity)
        {
            var result = await _sessionService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]

        [Authorize(Roles = "Admin")]
        public IActionResult Update(Session entity)
        {
            var result = _sessionService.Update(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("{entityId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _sessionService.GetByIdAsync(entityId);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{entityId:guid}")]

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _sessionService.Remove(entityId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _sessionService.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCount()
        {
            var result = await _sessionService.GetCount();
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetListWithFilter(BaseFilterringModel entity)
        {
            IEnumerable<Session> result = await _sessionService.GetFilterAsync(entity);
            return result!=null? Ok(result):BadRequest(result);
        }
    }
}