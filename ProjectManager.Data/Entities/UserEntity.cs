using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Data.Entities;

[Index(nameof(Email), IsUnique = true)]
public class UserEntity //Entity class is a class that represents a table in a database
{
    [Key]
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; } 
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
