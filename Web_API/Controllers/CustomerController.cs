using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business.Dtos;
using ProjectManager.Business.Interfaces;

namespace Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var customer = await _customerService.CreateCustomerAsync(dto);
        return customer == null ? BadRequest() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        var customer = await _customerService.GetAllCustomerAsync();
        return Ok(customer);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(CustomerUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _customerService.UpdateCustomerAsync(dto);
        return updated ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);

        if (customer == null)
            return NotFound();

        var deleted = await _customerService.DeleteCustomerAsync(customer);
        return deleted ? Ok() : BadRequest();
    }

}
