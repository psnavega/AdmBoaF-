using immob.Domains.Records.Property;
using immob.Services;
using Microsoft.AspNetCore.Mvc;

namespace immob.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            try
            {
                var result = await _propertyService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(Guid id)
        {
            try
            {
                var result = await _propertyService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProperty([FromBody] AddProperty req)
        {
            try
            {
                var result = await _propertyService.Add(req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] UpdateProperty req)
        {
            try
            {
                var result = await _propertyService.Update(id, req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{propertyId:guid}/remove/{ownerId:guid}")]
        public async Task<IActionResult> RemoveOwner(Guid propertyId, Guid ownerId)
        {
            try
            {
                var result = await _propertyService.DeleteOwner(propertyId, ownerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{propertyId:guid}/add/{ownerId:guid}")]
        public async Task<IActionResult> AddOwner(Guid propertyId, Guid ownerId)
        {
            try
            {
                var result = await _propertyService.AddOwner(propertyId, ownerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveOwner(Guid id)
        {
            try
            {
                var result = await _propertyService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
