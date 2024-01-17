using Microsoft.AspNetCore.Mvc;
using immob.Domains.Records.Owner;
using immob.Services;

namespace immob.Controllers;
[ApiController]
[Route("api/owners")]
public class OwnerController : ControllerBase
{
    private readonly OwnerService _ownerService;

    public OwnerController(OwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOwners()
    {
        try
        {
            var result = await _ownerService.GetAll();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOwner(Guid id)
    {
        try
        {
            var result = await _ownerService.GetById(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddOwner req)
    {
        try
        {
            var result = await _ownerService.Add(req);

            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] UpdateOwner req)
    {
        try
        {
            var result = await _ownerService.Update(id, req);

            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOwner(Guid id)
    {
        try
        {
            var result = await _ownerService.Delete(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
