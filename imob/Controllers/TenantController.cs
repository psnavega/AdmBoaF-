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
            try
            {
                var result = await _tenantService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenant(Guid id)
        {
            try
            {
                var result = await _tenantService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddTenant([FromBody] AddTenant req)
        {
            try
            {
                var result = await _tenantService.Add(req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateTenant(Guid id, [FromBody] UpdateTenant req)
        {
            try
            {
                var result = await _tenantService.Update(id, req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            try
            {
                var result = await _tenantService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{tenantId:guid}/rent/{propertyId:guid}")]
        public async Task<IActionResult> RentProperty(Guid tenantId, Guid propertyId)
        {
            try
            {
                var result = await _tenantService.RentProperty(tenantId, propertyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{tenantId:guid}/vacate/{propertyId:guid}")]
        public async Task<IActionResult> VacateProperty(Guid tenantId, Guid propertyId)
        {
            try
            {
                var result = await _tenantService.VacateProperty(tenantId, propertyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
