using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();
        EmployeeResponse GetById(string id);
        Task<EmployeeResponse> GetByNameAndPassword(AuthenticationRequest request);
        void Insert(EmployeeRequest request);
        void Update(EmployeeRequest request);
        void Delete(EmployeeRequest request);
        void Delete(string id);
    }
}
