using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach.Models
{
    [Table("EmployeeSkill")]
    public class EmployeeSkill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
