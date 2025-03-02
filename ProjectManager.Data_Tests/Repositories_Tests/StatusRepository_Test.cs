using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;
using ProjectManager.Data.Tests.SeedData;

namespace ProjectManager.Data.Tests.Repositories_Tests;

public class StatusRepository_Test
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
    public async Task GetAllStatusAsync_ShouldReturnAllStatus()
    {
        // Arrange
        var context = GetDataContext();
        context.Statuses.AddRange(TestData.StatusEntities);
        await context.SaveChangesAsync();

        IStatusRepository repository = new StatusRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(result.Count(), TestData.StatusEntities.Length);
    }
}