
namespace ProjectManager.Business.Dtos;

public class CustomerUpdateDto
{

    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
