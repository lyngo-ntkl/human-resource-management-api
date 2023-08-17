using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? IdentityCardNumber { get; set; }

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public int? PositionId { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    public virtual Position? Position { get; set; }
}
