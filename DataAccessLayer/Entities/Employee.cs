using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string IdentityCardNumber { get; set; } = null!;

    public string? EductionalLevel { get; set; }

    public string? Major { get; set; }

    public bool IsFormer { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordKey { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();
}
