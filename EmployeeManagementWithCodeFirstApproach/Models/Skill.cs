using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach.Models
{
    [Table("Skill")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public ICollection<EmployeeSkill> employeeSkill { get; set; }  
    }
}
