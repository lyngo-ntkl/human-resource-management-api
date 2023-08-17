using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Contract
{
    public string? EmployeeId { get; set; }

    public string ContractId { get; set; } = null!;

    public string ContractFile { get; set; } = null!;

    public string ElectronicSignature { get; set; } = null!;

    public string? ContractAnnex { get; set; }

    public short? LaborContractType { get; set; }

    public int? ContractTerm { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal BasicSalary { get; set; }

    public decimal? Allowance { get; set; }

    public int? AnnualLeave { get; set; }

    public int? ProbationaryPeriod { get; set; }

    public virtual Employee? Employee { get; set; }
}
