using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();
        Employee GetById(string id);
        void Insert(Employee entity);
        void Update(Employee entity);
        void Delete(Employee entity);
        void Delete(string id);
    }
}
