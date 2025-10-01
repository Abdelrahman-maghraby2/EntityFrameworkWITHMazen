using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alial.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string? UserName => Email.Split('@').ToString();

        // Navigation Property [One]
        // Ef Core -> Employee May Be Manage One Department [Optional]
        [InverseProperty(nameof(Department.Manager))]
        public virtual Department? ManagedDepartment { get; set; } = null!;
        public Address Address { get; set; } = null!;

        // Navigation Property [One]
        // Each Employee Must Work In One Department 
        [InverseProperty(nameof(Department.Employees))]
        public virtual Department EmployeeDepartment { get; set; } = null!;

        [ForeignKey(nameof(EmployeeDepartment))]
        public int? DepartmentId { get; set; }

        [InverseProperty(nameof(EmployeeProject.Employee))]
        public virtual EmployeeProject? EmployeeProject { get; set; }
    }
}
