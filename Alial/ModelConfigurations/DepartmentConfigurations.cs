using Alial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Alial.ModelConfigurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.ToTable("Departments", "Sales");

            D.HasKey(D => D.DeptId);

            D.Property(D => D.DeptId).UseIdentityColumn(10, 10);

            D.Property(D => D.DeptName)
            .HasColumnName("DepartmentName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasDefaultValue("HR");

            D.Property(D => D.DateOfCreation)
             .HasAnnotation("DataType", "DateTime")
             .HasDefaultValueSql("GetDate()");

            D.Ignore(D => D.Serial);

            D.HasData(
                new Department() { DeptId = 20, DeptName = "HR", DateOfCreation = new DateTime(2025, 10, 30), Serial = 1000 },
                new Department() { DeptId = 50, DeptName = "IT", DateOfCreation = new DateTime(2025, 1, 15), Serial = 2000 }
            );
        }
    }
}
