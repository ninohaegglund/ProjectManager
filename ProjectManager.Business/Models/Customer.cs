﻿

namespace ProjectManager.Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
