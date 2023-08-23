using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Position
{
    public int PositionId { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
