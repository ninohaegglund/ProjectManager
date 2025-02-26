

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Business.Dtos;

public class CustomerDto
{
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
