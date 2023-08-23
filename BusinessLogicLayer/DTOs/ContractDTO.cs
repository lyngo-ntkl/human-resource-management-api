using BusinessLogicLayer.DTOs.Request;

namespace BusinessLogicLayer.DTOs;

public class ContractDTO
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

    public virtual ICollection<AllowanceDTO> Allowances { get; set; } = new List<AllowanceDTO>();

    public virtual DepartmentDTO? Department { get; set; }

    //public virtual EmployeeDTO? Employee { get; set; }

    public virtual PositionDTO? Position { get; set; }
}
