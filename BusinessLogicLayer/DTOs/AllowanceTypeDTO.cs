namespace BusinessLogicLayer.DTOs;

public class AllowanceTypeDTO
{
    public int AllowanceTypeId { get; set; }

    public string AllowanceName { get; set; } = null!;

    public virtual ICollection<AllowanceDTO> Allowances { get; set; } = new List<AllowanceDTO>();
}
