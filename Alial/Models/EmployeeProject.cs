using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alial.Models
{
    public  class EmployeeProject
    {
        [Key]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [InverseProperty(nameof(Employee.EmployeeProject))]
        public virtual Employee Employee { get; set; } = null!;

        public int ProjectId { get; set; }

        [InverseProperty(nameof(Project.ProjectEmployees))]
        public virtual Project Project { get; set; } = null!;
    }
}
