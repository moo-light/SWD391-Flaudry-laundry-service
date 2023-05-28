using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PackageController : BaseController, IWebController<Package>
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Package entity)
        {
            var result = await _packageService.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid entityId)
        {
            var result = _packageService.Remove(entityId);
            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _packageService.GetAllAsync();
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDAsync(Guid entityId)
        {
            var result = await _packageService.GetByIdAsync(entityId);
            return (result != null ? Ok() : BadRequest());
        }
        [HttpPut]
        public IActionResult Update(Package entity)
        {
            var result = _packageService.Update(entity);
            return result ? Ok(result) : BadRequest();
        }
    }
}
