using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementWithCodeFirstApproach.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(40)")]
        public string Email { get; set; }

        [Column("Phone", TypeName = "varchar(15)")]
        public string Phone { get; set; }

        [Column("DepartmentId", TypeName = "int")]
        public int DepartmentId { get; set; }

        [Column("IsActive", TypeName = "varchar(5)")]
        public string IsActive { get; set; }


        public Department Department { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set;}
    }
}
