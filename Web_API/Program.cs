using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Interfaces;
using ProjectManager.Business.Repositories;
using ProjectManager.Business.Services;
using ProjectManager.Data.Contexts;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IProjectCategoryService, ProjectCategoryService>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IProjectCategoryRepository, ProjectCategoryRepository>();
builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//2:20:00 går igenom frontend med js och html. (Lektion 4 - Repository Patterns)