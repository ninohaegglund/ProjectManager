using ProjectManager.Business.Interfaces;
using ProjectManager.Data.Entities;
using ProjectManager.Presentation.Dialogs;

public class MenuDialogs : IMenuDialogs
{
    private readonly IUserService _userService;
    private readonly IProjectService _projectService;

    public MenuDialogs(IUserService userService, IProjectService projectService)
    {
        _userService = userService;
        _projectService = projectService;
    }

    public void ShowMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Show Customers");
            Console.WriteLine("2. Manage Projects");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowCustomersPage();
                    break;

                case "2":
                    ShowManageProjectsPage();
                    break;

                case "3":
                    Console.WriteLine("Exiting program...");
                    running = false;
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option, press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ShowCustomersPage()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            var users = _userService.GetUsers();
            Console.WriteLine("Customer List:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName} ({user.Email})");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Edit Customer");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomer();
                    break;

                case "2":
                    EditCustomer();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid option, press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void AddCustomer()
    {
        Console.Clear();
        Console.Write("First Name: ");
        string firstName = Console.ReadLine() ?? "";
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";

        var newUser = new UserEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        var createdUser = _userService.CreateUser(newUser);
        Console.WriteLine($"Customer {createdUser.FirstName} {createdUser.LastName} added with ID {createdUser.Id}.");
        Console.ReadLine();
    }

    private void EditCustomer()
    {
        Console.Clear();
        Console.Write("Enter Customer ID to edit: ");
        var customerId = int.Parse(Console.ReadLine());
        var user = _userService.GetUserById(customerId);
        if (user != null)
        {
            Console.WriteLine($"Editing customer: {user.FirstName} {user.LastName}");
            Console.Write("New First Name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("New Last Name: ");
            user.LastName = Console.ReadLine();
            Console.Write("New Email: ");
            user.Email = Console.ReadLine();
            Console.Write("New Password: ");
            user.Password = Console.ReadLine();

            _userService.UpdateUser(user);
            Console.WriteLine("Customer updated successfully!");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
        Console.ReadLine();
    }

    public void ShowManageProjectsPage()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Manage Projects:");
            Console.WriteLine("1. Add Project");
            Console.WriteLine("2. Edit Project");
            Console.WriteLine("3. Show Projects");
            Console.WriteLine("4. Return to Main Menu");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProject();
                    break;
                case "2":
                    EditProject();
                    break;
                case "3":
                    ShowProjectsPage();  // Calls your ShowProjectsPage method
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option, press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }


    public void ShowProjectsPage()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();

    
            var projects = _projectService.GetProjects();

            if (projects.Any())
            {
                foreach (var project in projects)
                {
                    var customer = _userService.GetUserById(project.CustomerId);
                    Console.WriteLine($"Project ID: {project.Id}, Name: {project.Name}");
                    Console.WriteLine($"Customer: {customer?.FirstName} {customer?.LastName ?? "Unknown"}");
                    Console.WriteLine($"Start Date: {project.StartDate.ToShortDateString()}, End Date: {(project.EndDate.HasValue ? project.EndDate.Value.ToShortDateString() : "Not set")}");
                    Console.WriteLine($"Description: {project.Description ?? "No description provided."}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No projects available.");
            }

            
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add Project");
            Console.WriteLine("2. Edit Project");
            Console.WriteLine("3. Return to Manage Projects");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProject();
                    break;

                case "2":
                    EditProject();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid option, press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }


    private void AddProject()
    {
        Console.Clear();
        Console.Write("Project Name: ");
        string projectName = Console.ReadLine() ?? "";

        Console.Write("Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Start Date (yyyy-mm-dd): ");
        DateTime startDate;
        while (!DateTime.TryParse(Console.ReadLine(), out startDate))
        {
            Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-mm-dd).");
        }

        Console.Write("End Date (yyyy-mm-dd, leave blank if ongoing): ");
        DateTime? endDate = null;
        string endDateInput = Console.ReadLine() ?? "";
        if (!string.IsNullOrEmpty(endDateInput))
        {
            while (!DateTime.TryParse(endDateInput, out var parsedEndDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid end date (yyyy-mm-dd).");
                endDateInput = Console.ReadLine() ?? "";
            }
            endDate = DateTime.Parse(endDateInput);
        }

        var newProject = new ProjectEntity
        {
            Name = projectName,
            CustomerId = customerId,

        };

        var createdProject = _projectService.CreateProject(newProject);
        Console.WriteLine($"Project '{createdProject.Name}' added successfully!");
        Console.ReadLine();
    }

    private void EditProject()
    {
        Console.Clear();
        Console.Write("Enter Project ID to edit: ");
        var projectId = int.Parse(Console.ReadLine());
        var project = _projectService.GetProjectById(projectId);
        if (project != null)
        {
            Console.WriteLine($"Editing project: {project.Name}");
            Console.Write("New Project Name: ");
            project.Name = Console.ReadLine();


            Console.Write("New Description (leave blank to keep current): ");
            string newDescription = Console.ReadLine() ?? "";
            if (!string.IsNullOrEmpty(newDescription)) project.Description = newDescription;

            Console.Write("New Start Date (yyyy-mm-dd, leave blank to keep current): ");
            string newStartDateInput = Console.ReadLine() ?? "";
            if (!string.IsNullOrEmpty(newStartDateInput))
            {
                DateTime newStartDate;
                while (!DateTime.TryParse(newStartDateInput, out newStartDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-mm-dd).");
                    newStartDateInput = Console.ReadLine() ?? "";
                }
                project.StartDate = newStartDate;
            }

            Console.Write("New End Date (yyyy-mm-dd, leave blank to keep current): ");
            string newEndDateInput = Console.ReadLine() ?? "";
            if (!string.IsNullOrEmpty(newEndDateInput))
            {
                DateTime newEndDate;
                while (!DateTime.TryParse(newEndDateInput, out newEndDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid end date (yyyy-mm-dd).");
                    newEndDateInput = Console.ReadLine() ?? "";
                }
                project.EndDate = newEndDate;
            }



            Console.Write("New Customer ID (leave blank to keep current): ");
            string customerIdInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(customerIdInput))
            {
                project.CustomerId = int.Parse(customerIdInput);
            }

            _projectService.UpdateProject(project);
            Console.WriteLine("Project updated successfully!");
        }
        else
        {
            Console.WriteLine("Project not found.");
        }
        Console.ReadLine();
    }
}
