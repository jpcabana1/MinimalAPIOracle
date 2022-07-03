using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public decimal EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal? ManagerId { get; set; }
        public string JobTitle { get; set; } = null!;

        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
