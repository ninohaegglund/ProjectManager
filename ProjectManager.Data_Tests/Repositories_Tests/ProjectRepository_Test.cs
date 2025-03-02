using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;
using ProjectManager.Data.Tests.SeedData;

namespace ProjectManager.Data.Tests.Repositories_Tests;

public class ProjectRepository_Test
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var conxext = new DataContext(options);
        conxext.Database.EnsureCreated();
        return conxext;
    }
    [Fact]
    public async Task AddProjectAsync_ShouldAddAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Customers.AddRange(TestData.CustomerEntities);
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.AddAsync(projectEntity);

        // Assert
        Assert.NotEqual(0, result!.Id);
    }
    [Fact]
    public async Task GetAllProjectAsync_ShouldReturnAllProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Customers.AddRange(TestData.CustomerEntities);
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Projects.AddRange(TestData.ProjectEntities);
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ProjectEntities.Length, result.Count());
    }
    [Fact]
    public async Task GetProjectAsync_ShouldReturnProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Customers.AddRange(TestData.CustomerEntities);
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Projects.AddRange(TestData.ProjectEntities);
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        // Act
        var result = await repository.GetAsync(x => x.Id == 1);

        // Assert
        Assert.Equal(1, result!.Id);
    }
    [Fact]
    public async Task UpdateProjectAsync_ShouldUpdateProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Customers.AddRange(TestData.CustomerEntities);
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];
        context.Projects.Add(projectEntity);
        await context.SaveChangesAsync();

        // Act
        projectEntity.Name = "Test Project";
        projectEntity.Description = "Updated Description";
        projectEntity.StartDate = DateTime.Now;
        projectEntity.EndDate = DateTime.Now;
        projectEntity.CustomerId = 1;
        projectEntity.ProjectCategoryId = 1;
        projectEntity.StatusId = 1;
        projectEntity.ProjectTaskId = 1;

        var updateProject = await repository.UpdateAsync(projectEntity);
        var result = await repository.GetAsync(x => x.Id == projectEntity.Id);

        // Assert
        Assert.NotEqual(0, result!.Id);
        Assert.Equal("Test Project", result.Name);
        Assert.Equal("Updated Description", result.Description);
        Assert.Equal(projectEntity.StartDate, result.StartDate);
        Assert.Equal(projectEntity.EndDate, result.EndDate);
        Assert.Equal(1, result.CustomerId);
        Assert.Equal(1, result.ProjectCategoryId);
        Assert.Equal(1, result.StatusId);
        Assert.Equal(1, result.ProjectTaskId);
    }
    [Fact]
    public async Task DeleteProjectAsync_ShouldDeleteProject()
    {
        // Arrange
        var context = GetDataContext();

        context.Customers.AddRange(TestData.CustomerEntities);
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectRepository repository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectEntities[0];
        context.Projects.Add(projectEntity);
        await context.SaveChangesAsync();

        // Act
        await repository.DeleteAsync(projectEntity);

        // Assert
        var result = await repository.GetAsync(x => x.Id == projectEntity.Id);
        
        Assert.Null(result);
    }
}