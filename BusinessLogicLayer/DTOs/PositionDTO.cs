namespace BusinessLogicLayer.DTOs;

public class PositionDTO
{
    public int PositionId { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<ContractDTO> Contracts { get; set; } = new List<ContractDTO>();
}
