using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Payroll
{
    public string PayrollId { get; set; } = null!;

    public string? ContractId { get; set; }

    public DateTime PayDate { get; set; }

    public int DaysOff { get; set; }

    public virtual ICollection<Bonuse> Bonuses { get; set; } = new List<Bonuse>();

    public virtual Contract? Contract { get; set; }
}
