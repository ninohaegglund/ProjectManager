﻿

namespace ProjectManager.Business.Models;

public class ProjectTask
{
    public int Id { get; set; }
    public string TaskName { get; set; } = null!;

    public IEnumerable<Project> Projects { get; set; } = [];

}
