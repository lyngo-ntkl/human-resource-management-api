using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Bonuse
{
    public string BonusId { get; set; } = null!;

    public string PayrollId { get; set; } = null!;

    public int BonusTypeId { get; set; }

    public string Reason { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual BonusType BonusType { get; set; } = null!;

    public virtual Payroll Payroll { get; set; } = null!;
}
