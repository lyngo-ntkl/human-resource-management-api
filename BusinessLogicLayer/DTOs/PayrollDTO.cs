namespace BusinessLogicLayer.DTOs;

public class PayrollDTO
{
    public string PayrollId { get; set; } = null!;

    public string? ContractId { get; set; }

    public DateTime PayDate { get; set; }

    public int? WorkDay { get; set; }
}
