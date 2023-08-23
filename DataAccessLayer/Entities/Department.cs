using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
