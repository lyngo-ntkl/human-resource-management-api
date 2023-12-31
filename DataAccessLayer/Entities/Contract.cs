﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Contract
{
    public string ContractId { get; set; } = null!;

    public string? EmployeeId { get; set; }

    public int? DepartmentId { get; set; }

    public int? PositionId { get; set; }

    public string ContractFile { get; set; } = null!;

    public string? ElectronicSignature { get; set; }

    public string? ContractAnnex { get; set; }

    public short? LaborContractType { get; set; }

    public int? ContractTerm { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? AnnualLeave { get; set; }

    public int? ProbationaryPeriod { get; set; }

    public decimal BasicSalary { get; set; }

    public decimal? TotalAllowance { get; set; }

    public virtual ICollection<Allowance> Allowances { get; set; } = new List<Allowance>();

    public virtual Department? Department { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual Position? Position { get; set; }
}
