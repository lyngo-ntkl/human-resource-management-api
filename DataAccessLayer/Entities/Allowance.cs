using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Allowance
{
    public string ContractId { get; set; } = null!;

    public int AllowanceTypeId { get; set; }

    public decimal Amount { get; set; }

    public virtual AllowanceType AllowanceType { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;
}
