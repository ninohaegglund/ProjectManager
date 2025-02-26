using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business.Interfaces;

namespace Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectTaskController(IProjectTaskService projectTaskService) : ControllerBase
{
    private readonly IProjectTaskService _projectTaskService = projectTaskService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectTaskService.GetAllProjectTaskAsync();
        return Ok(result);
    }
}
