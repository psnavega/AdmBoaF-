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
            var result = await _propertyService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(Guid id)
        {
            var result = await _propertyService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddProperty([FromBody] AddProperty req)
        {
            var result = await _propertyService.Add(req);
            return Ok(result);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] UpdateProperty req)
        {
            var result = await _propertyService.Update(id, req);
            return Ok(result);
        }

        [HttpPatch("{propertyId:guid}/remove/{ownerId:guid}")]
        public async Task<IActionResult> RemoveOwner(Guid propertyId, Guid ownerId)
        {
            var result = await _propertyService.DeleteOwner(propertyId, ownerId);
            return Ok(result);
        }

        [HttpPatch("{propertyId:guid}/add/{ownerId:guid}")]
        public async Task<IActionResult> AddOwner(Guid propertyId, Guid ownerId)
        {
            var result = await _propertyService.AddOwner(propertyId, ownerId);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveOwner(Guid id)
        {
            var result = await _propertyService.Delete(id);
            return Ok(result);
        }
    }
}
