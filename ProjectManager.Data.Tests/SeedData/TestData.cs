using ProjectManager.Data.Entities;

namespace ProjectManager.Data.Tests.SeedData;

public static class TestData
{

    public static readonly CustomerEntity[] CustomerEntities =
    [
        new CustomerEntity {Id = 1,CustomerName = "Nintendo Co.,Ltd", Email = "info@nintendo.com" },
        new CustomerEntity {Id = 2,CustomerName = "Wayne Enterprises", Email = "bruce@wayne.com" },
        new CustomerEntity {Id = 3,CustomerName = "Firefly AB", Email = "info@firefly.se" },
    ];

    public static readonly ProjectEntity[] ProjectEntities =
    [

        new ProjectEntity {
            Name = "Titan",
            Description = "Chemical solution created by Dr. Penelope Young",
            StartDate = new DateTime(2025,12,12),
            EndDate = new DateTime(2026,05,12),
            StatusId = 2,
            CustomerId = 2,
            ProjectCategoryId = 2,
            ProjectTaskId = 1 
        },
    ];

    public static readonly ProjectCategoryEntity[] ProjectCategoryEntities = 
    [
        new ProjectCategoryEntity {Id = 1,CategoryName = "Consulting" },
        new ProjectCategoryEntity {Id = 2,CategoryName = "Development" },
        new ProjectCategoryEntity {Id = 3,CategoryName = "Maintenance" },
    ];

    public static readonly ProjectTaskEntity[] ProjectTaskEntities = 
    [
        new ProjectTaskEntity {Id = 1,TaskName = "Initial Planning" },
        new ProjectTaskEntity {Id = 2,TaskName = "Development Work" },
        new ProjectTaskEntity {Id = 3,TaskName = "Final Review" },
    ];

    public static readonly StatusEntity[] StatusEntities =
   [
        new StatusEntity {Id = 1,StatusName = "Not Started" },
        new StatusEntity {Id = 2,StatusName = "In Progress" },
        new StatusEntity {Id = 3,StatusName = "Completed" },
    ];




    //Data för att populera tabeller i databasen
}
