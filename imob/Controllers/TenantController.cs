using immob.Domains.Dtos;
using immob.Domains.Records.Tenant;
using immob.Services;
using Microsoft.AspNetCore.Mvc;

namespace immob.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantController : ControllerBase
    {
        private readonly TenantService _tenantService;

        public TenantController(TenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            var result = await _tenantService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenant(Guid id)
        {
            var result = await _tenantService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddTenant([FromBody] AddTenant req)
        {
            var result = await _tenantService.Add(req);
            return Ok(result);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateTenant(Guid id, [FromBody] UpdateTenant req)
        {
            var result = await _tenantService.Update(id, req);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<bool> DeleteTenant(Guid id)
        {
            var result = await _tenantService.Delete(id);
            return result;
        }
    }
}
