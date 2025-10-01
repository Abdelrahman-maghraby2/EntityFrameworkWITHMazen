using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alial.Models
{
    public class StudentCourse
    {
        public int Grade { get; set; }

        [InverseProperty(nameof(Student.StdCourses))]
        public virtual Student Student { get; set; } = null!;

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }


        [InverseProperty(nameof(Course.CrStudents))]
        public virtual Course Course { get; set; } = null!;

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
    }
}
