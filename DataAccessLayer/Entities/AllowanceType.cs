using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class AllowanceType
{
    public int AllowanceTypeId { get; set; }

    public string AllowanceName { get; set; } = null!;

    public virtual ICollection<Allowance> Allowances { get; set; } = new List<Allowance>();
}
