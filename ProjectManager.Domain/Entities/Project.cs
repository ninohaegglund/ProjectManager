﻿

namespace ProjectManager.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
}
