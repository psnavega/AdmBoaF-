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
        var result = await _ownerService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOwner(Guid id)
    {
        var result = await _ownerService.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddOwner req)
    {
        var result = await _ownerService.Add(req);

        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] UpdateOwner req)
    {
        var result = await _ownerService.Update(id, req);


        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<bool> DeleteOwner(Guid id)
    {
        var result = await _ownerService.Delete(id);

        return result;
    }
}
