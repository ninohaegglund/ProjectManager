using ProjectManager.Business.Services;
using ProjectManager.Data.Contexts;
using ProjectManager.Presentation.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Business.Repositories;
using ProjectManager.Business.Interfaces;
using ProjectManager.Data.Interfaces;
using ProjectManager.Data.Repositories;

var serviceCollection = new ServiceCollection(); 

serviceCollection.AddDbContext<DataContext>(options => 
    options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\Databasteknik\repos\WebApplication1\ProjectManager.Data\Database\product_database.mdf;Integrated Security=True;Connect Timeout=30"));

// Register services using interfaces
serviceCollection.AddScoped<IUserService, UserService>();
serviceCollection.AddScoped<IProjectService, ProjectService>();
serviceCollection.AddScoped<IMenuDialogs, MenuDialogs>();
serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
serviceCollection.AddScoped<IUserRepository, UserRepository>();
serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<IMenuDialogs>();

while (true) 
{
    menuDialogs.ShowMenu();
}
