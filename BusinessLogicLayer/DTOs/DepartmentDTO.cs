namespace BusinessLogicLayer.DTOs;

public class DepartmentDTO
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<ContractDTO> Contracts { get; set; } = new List<ContractDTO>();
}
