using ProjectManager.Business.Dtos;
using ProjectManager.Business.Models;
using ProjectManager.Data.Entities;

namespace ProjectManager.Business.Factories;

public static class CustomerFactory
{
    public static CustomerDto Create() => new();

    public static Customer? Create(CustomerEntity entity)
    {
        var customer = new Customer()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            Email = entity.Email,
            Projects = []
        };

        if (entity.Projects != null)
        {
            var projects = new List<Project>();
            foreach (var project in entity.Projects)
                projects.Add(new Project
                {
                    Id = project.Id,
                    Description = project.Description,
                });
            
             customer.Projects = projects;
        }

        return customer;
    }

    public static CustomerEntity Create(CustomerDto dto) => new()
    {
        CustomerName = dto.CustomerName,
        Email = dto.Email
    };


    public static CustomerUpdateDto Create(Customer customer) => new()
    {
        Id = customer.Id,
        CustomerName = customer.CustomerName,
        Email = customer.Email
    };

    public static CustomerEntity Create(CustomerUpdateDto dto) => new()
    {
        Id = dto.Id,
        CustomerName = dto.CustomerName,
        Email = dto.Email
    };
}
