using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Entities;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;
using ProjectManager.Data.Tests.SeedData;

namespace ProjectManager.Data.Tests.Repositories_Tests;

public class ProjectCategoryRepository_Test
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
    public async Task GetAllProjectCategoryAsync_ShouldReturnAllProjectCategory()
    {
        // Arrange
        var context = GetDataContext();
        context.Categories.AddRange(TestData.ProjectCategoryEntities);
        await context.SaveChangesAsync();

        IProjectCategoryRepository repository = new ProjectCategoryRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(result.Count(), TestData.ProjectCategoryEntities.Length);
    }
}
