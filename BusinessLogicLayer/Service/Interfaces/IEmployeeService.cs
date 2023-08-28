using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> Get();
        EmployeeResponse GetById(string id);
        Task<EmployeeResponse> GetByEmailAndPassword(AuthenticationRequest request);
        EmployeeResponse Insert(EmployeeRequest request);
        EmployeeResponse Update(EmployeeRequest request);
        //EmployeeResponse Delete(EmployeeRequest request);
        EmployeeResponse Delete(string id);
    }
}
