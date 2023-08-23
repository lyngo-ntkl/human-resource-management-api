namespace BusinessLogicLayer.DTOs;

public class AllowanceDTO
{
    public string ContractId { get; set; } = null!;

    public int AllowanceTypeId { get; set; }

    public decimal Amount { get; set; }

    public virtual AllowanceTypeDTO AllowanceType { get; set; } = null!;

    public virtual ContractDTO Contract { get; set; } = null!;
}
