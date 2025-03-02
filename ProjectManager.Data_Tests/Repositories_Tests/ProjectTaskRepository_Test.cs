using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;
using ProjectManager.Data.Tests.SeedData;

namespace ProjectManager.Data.Tests.Repositories_Tests;

public class ProjectTaskRepository_Test
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
    public async Task GetAllProjectTaskAsync_ShouldReturnAllProjectTask()
    {
        // Arrange
        var context = GetDataContext();
        context.Tasks.AddRange(TestData.ProjectTaskEntities);
        await context.SaveChangesAsync();

        IProjectTaskRepository repository = new ProjectTaskRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(result.Count(), TestData.ProjectTaskEntities.Length);
    }
}
