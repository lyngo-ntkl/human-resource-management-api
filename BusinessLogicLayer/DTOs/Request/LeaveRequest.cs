using BusinessLogicLayer.DTOs.Request;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTOs.Request;

public enum LeaveStatus
{
    Approved, Processed, Rejected
}
public class LeaveRequest
{
    //public int LeaveId { get; set; }
    [Required]
    public string EmployeeId { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public short Type { get; set; }
    [Required]
    public string? Reason { get; set; }

    //public virtual Employee Employee { get; set; } = null!;
}
