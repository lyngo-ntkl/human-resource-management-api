using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class BonusType
{
    public int BonusTypeId { get; set; }

    public string BonusName { get; set; } = null!;

    public virtual ICollection<Bonuse> Bonuses { get; set; } = new List<Bonuse>();
}
