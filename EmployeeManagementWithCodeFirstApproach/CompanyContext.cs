using EmployeeManagementWithCodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach
{
    public class CompanyContext:DbContext
    {
        public CompanyContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=LAPTOP-HOHQ552T\SQLEXPRESS;Database=EmployeeManagementSystemWithCodeFirstData;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }    
        public DbSet<Skill>Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(es => es.Id);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(e => e.Employee)
                .WithMany(g => g.EmployeeSkills)
                .HasForeignKey(es => es.Id);
                

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.employeeSkill)
                .HasForeignKey(es => es.SkillId);
        }

    }
}
