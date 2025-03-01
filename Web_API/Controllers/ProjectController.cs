using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business.Dtos;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Services;

namespace Web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] ProjectDto dto)
    {
        if (!ModelState.IsValid && dto.CustomerId < 1)
            return BadRequest();

        var result = await _projectService.CreateProjectAsync(dto);
        return result ? Created("", null) : Problem();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProject()
    {
        var project = await _projectService.GetAllProjectAsync();
        return Ok(project);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject(ProjectUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _projectService.UpdateProjectAsync(dto);
        return updated ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);

        if (project == null)
            return NotFound();

        var deleted = await _projectService.DeleteProjectAsync(project);
        return deleted ? Ok() : BadRequest();
    }
}
