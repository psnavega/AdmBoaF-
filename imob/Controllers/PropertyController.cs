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

        [HttpDelete("{id:guid}")]
        public async Task<bool> DeleteProperty(Guid id)
        {
            var result = await _propertyService.Delete(id);
            return result;
        }
    }
}
