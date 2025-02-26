using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business.Interfaces;

namespace Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController(IStatusService statusService) : ControllerBase
{
    private readonly IStatusService _statusService = statusService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _statusService.GetAllStatusAsync();
        return Ok(result);
    }
}
