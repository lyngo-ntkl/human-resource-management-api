using BusinessLogicLayer.DTOs.Request;

namespace BusinessLogicLayer.DTOs.Response;

public class LeaveResponse
{
    public string LeaveId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; }

    public short Type { get; set; }

    public string? Reason { get; set; }

    //public virtual EmployeeDTO Employee { get; set; } = null!;
}
