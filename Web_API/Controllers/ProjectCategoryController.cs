using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business.Interfaces;

namespace Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectCategoryController(IProjectCategoryService projectCategoryService) : ControllerBase
{
    private readonly IProjectCategoryService _projectCategoryService = projectCategoryService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectCategoryService.GetAllProjectCategoryAsync();
        return Ok(result);
    }
}
