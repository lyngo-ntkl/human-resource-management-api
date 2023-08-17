using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Leave
{
    public int LeaveId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public short Status { get; set; }

    public short Type { get; set; }

    public string? Reason { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
