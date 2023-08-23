using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Response
{
    public class EmployeeResponse
    {
        public string EmployeeId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateTime Birthday { get; set; }

        public string Address { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string IdentityCardNumber { get; set; } = null!;

        public string? EductionalLevel { get; set; }

        public string? Major { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Token { get; set; }

        //public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        //public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();
    }
}
