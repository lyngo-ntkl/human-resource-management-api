using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;

namespace BusinessLogicLayer.Service.Interfaces
{
    public interface ILeaveService
    {
        IEnumerable<LeaveResponse> Get();
        LeaveResponse GetById(string id);
        LeaveResponse Insert(LeaveRequest request);
        LeaveResponse Update(string id, LeaveRequest request);
        LeaveResponse Delete(string id);
    }
}
