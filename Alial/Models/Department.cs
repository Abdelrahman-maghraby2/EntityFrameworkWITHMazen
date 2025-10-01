using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alial.Models
{
    //[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]


    public class Department
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Serial { get; set; }

        [InverseProperty(nameof(Employee.ManagedDepartment))]
        public virtual Employee Manager { get; set; } = null!;

        public int? DeptManagerId { get; set; }

        // Navigation Property [One]
        // Department Contains Many Employees
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
