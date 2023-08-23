using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Leave
{
    public Guid LeaveId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; } = null!;

    public short Type { get; set; }

    public string? Reason { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
