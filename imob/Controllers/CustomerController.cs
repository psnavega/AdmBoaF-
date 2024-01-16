using Microsoft.AspNetCore.Mvc;
using immob.Domains.Records.Customer;
using immob.Services;

namespace immob.Controllers;
[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var result = await _customerService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        var result = await _customerService.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddCustomer req)
    {
        var result = await _customerService.Add(req);

        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomer req)
    {
        var result = await _customerService.Update(id, req);


        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<bool> DeleteCustomer(Guid id)
    {
        var result = await _customerService.Delete(id);

        return result;
    }
}
