using Alial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alial.DbContexts
{
    internal class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies()
                optionsBuilder.UseSqlServer("Server = .; Database = CompanyG06 ; Trusted_Connection = true; TrustServerCertificate=true");
                optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Employee>()
                        .HasOne(E => E.ManagedDepartment)
                        .WithOne(D => D.Manager)
                        .HasForeignKey<Department>(D => D.DeptManagerId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>()
                        .OwnsOne(E => E.Address, OE =>
                        {
                            OE.Property(A => A.City).HasColumnName("EmployeeCity");
                            OE.Property(A => A.Country).HasColumnName("EmployeeCountry");
                            OE.Property(A => A.Street).HasColumnName("EmployeeStreet");
                        });

            modelBuilder.Entity<Employee>()
                        .HasOne<EmployeeCar>()
                        .WithOne(E => E.Employee)
                        .HasForeignKey<EmployeeCar>(EC => EC.EmployeeId);

            modelBuilder.Entity<Car>()
                        .HasOne<EmployeeCar>()
                        .WithOne(E => E.Car)
                        .HasForeignKey<EmployeeCar>(EC => EC.CarId);

            modelBuilder.Entity<EmployeeCar>().HasKey(EC => EC.EmployeeId);


            modelBuilder.Entity<Employee>()
                        .HasOne(E => E.EmployeeDepartment)
                        .WithMany(D => D.Employees)
                        .HasForeignKey(E => E.DepartmentId)
                        .IsRequired(false)// Make Relationship Required [FK Not Allow Null]	
                        .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Department>()
            //			.HasMany(D => D.Employees)
            //			.WithOne(E => E.EmployeeDepartment)
            //			.HasForeignKey(E => E.DepartmentId)
            //			.IsRequired()// Make Relationship Required [FK Not Allow Null]	
            //			.OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<EmployeeProject>().HasKey(EP => EP.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(EP => EP.Employee)
                        .WithOne(E => E.EmployeeProject)
                        .HasForeignKey<EmployeeProject>(EP => EP.EmployeeId);


            modelBuilder.Entity<EmployeeProject>()
                        .HasOne(EP => EP.Project)
                        .WithMany(P => P.ProjectEmployees)
                        .HasForeignKey(EP => EP.ProjectId);

            //modelBuilder.Entity<Student>()
            //			.HasMany(S => S.Courses)
            //			.WithMany(C => C.Students)
            //			.UsingEntity(RT => 
            //			{
            //				RT.ToTable("Hamda");
            //		    });

            modelBuilder.Entity<StudentCourse>().HasKey(SC => new { SC.StudentId, SC.CourseId });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
