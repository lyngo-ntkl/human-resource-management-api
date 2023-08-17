using BusinessObjects.Models;
using DataAccessLayer.Service.Interfaces;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
