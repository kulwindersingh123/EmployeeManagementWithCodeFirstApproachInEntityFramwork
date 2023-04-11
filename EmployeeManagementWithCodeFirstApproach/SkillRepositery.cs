using EmployeeManagementWithCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach
{
    public class SkillRepositery
    {
        public static void ShowSkillRepositeryTable()
        {
            CompanyContext SkillContext = new CompanyContext();
            List<Skill> skills = SkillContext.Skills.ToList();
            foreach (Skill skill in skills)
            {
                Console.WriteLine("Skill_Id={0} | Skill_Name:{1} | IsActive:{2}",
               skill.Id, skill.Name, skill.IsActive);
            }
        }
        public static void insertSkill()
        {
            CompanyContext SkillContext = new CompanyContext();
            
                Console.WriteLine("Enter name of skill:");
                string skillName = Console.ReadLine();

                Console.WriteLine("Is skill active?yes/no");
                string isSkillActive = Console.ReadLine();

                if (string.IsNullOrEmpty(skillName) && string.IsNullOrEmpty(isSkillActive))
                {
                    Console.WriteLine("Please enter something!");
                }
                else
                {
                    Skill insertSkill = new Skill()
                    {
                        //Id = IdForskill,
                        Name = skillName,
                        IsActive = isSkillActive,
                    };
                    using (CompanyContext Skillcontext = new CompanyContext())
                    {
                    try
                    {

                        SkillContext.Skills.Add(insertSkill);
                        SkillContext.SaveChanges();
                    }
                    catch (SystemException e) 
                    {
                        Console.WriteLine("Exception Occured:"+e.Message);
                    }
                    }
                    Console.WriteLine("Insertion sucessfull");

                }
                Console.WriteLine("Here are elements in Skill After insertion:");
                SkillRepositery.ShowSkillRepositeryTable();

            


        }

        public static void ReadSkillFromExistingTable()
        {
            CompanyContext skillcontext = new CompanyContext();
            Console.WriteLine("Enter '1' for read one specific row and '2' all rows:");
            int.TryParse(Console.ReadLine(), out int userChoiceForRead);
            switch (userChoiceForRead)
            {
                case 1:
                    Skill skill = new Skill();
                    Console.WriteLine("Enter the Skill_Id which you want to read row:");
                    int.TryParse(Console.ReadLine(), out int skillIdForReadSpecificRow);
                    skill = skillcontext.Skills.Find(skillIdForReadSpecificRow);
                    if (skillIdForReadSpecificRow == null)
                    {
                        Console.WriteLine("Row of given Skill is not in table!");
                    }
                    else
                    {
                        Console.WriteLine(skill.Id + " | " + skill.Name + " | " + skill.IsActive);

                    }

                    break;
                case 2:
                    SkillRepositery.ShowSkillRepositeryTable();
                    break;
                default:
                    Console.WriteLine("Enter valid input.");
                    break;
            }



        }

        public static void UpdateSkillTable()
        {
            CompanyContext skillcontext = new CompanyContext();
            Console.WriteLine("Here are rows present in skill table:");
            SkillRepositery.ShowSkillRepositeryTable();
            Console.WriteLine("Enter the Skill ID which you want to update:");
            int.TryParse(Console.ReadLine(), out int skillIDForUpdation);

            Skill skill = skillcontext.Skills.Find(skillIDForUpdation);
            if (skill == null)
            {
                Console.WriteLine("There is not any skill present with this ID!");
            }
            else
            {
                Console.WriteLine("Enter 1 to update ID of skill.\nEnter 2 to update Name of skill.\nEnter 3 to update status of skill.");
                Console.WriteLine("Note,You can't update skill_ID beacuse that is key in table.");
                int.TryParse(Console.ReadLine(), out int userChoiceForUpdateWhichColoumn);

                switch (userChoiceForUpdateWhichColoumn)
                {
                    case 1:
                        Console.WriteLine("Enter new Id of skill");

                        int.TryParse(Console.ReadLine(), out int skillId);
                        if (skillcontext.Skills.Find(skillId) != null)
                        {
                            skill.Id = skillId;
                        }
                        else
                            Console.WriteLine("Forgien key can't be updated!");

                        break;

                    case 2:
                        Console.WriteLine("Enter new name of skill:");
                        string newNameGivenByUser = Console.ReadLine();
                        if (string.IsNullOrEmpty(newNameGivenByUser))
                        {
                            Console.WriteLine("Please enter somthing!");

                        }
                        else
                        {
                            skill.Name = newNameGivenByUser;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter new status of skill:");
                        string skillIsActive = Console.ReadLine();
                        if (string.IsNullOrEmpty(skillIsActive))
                        {
                            Console.WriteLine("Please enter somthing!");

                        }
                        else
                        {
                            skill.IsActive = skillIsActive;
                        }
                        break;

                }

                skillcontext.SaveChanges();

            }
            Console.WriteLine("After updation skill table is:");
            SkillRepositery.ShowSkillRepositeryTable();

        }



        public static void DeteteskillRows()
        {
            CompanyContext skillcontext = new CompanyContext();
            Console.WriteLine("Here are rows present in skill table:");
            SkillRepositery.ShowSkillRepositeryTable();

            Console.WriteLine("press 1 to delete a single row from Skill,\n 2 to Delete all rows ");

            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the skillsData Id to delete:");
                    int.TryParse(Console.ReadLine(), out int skillIdToBeDeleted);
                    Skill skillThatWillDeleted = skillcontext.Skills.Find(skillIdToBeDeleted);
                    if (skillThatWillDeleted != null)
                    {
                        skillcontext.Skills.Remove(skillThatWillDeleted);
                        Console.WriteLine("Row deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("There is no record found with id :" + skillIdToBeDeleted);
                    }
                    skillcontext.SaveChanges();
                    break;
                case 2:
                    List<Skill> skillList = skillcontext.Skills.ToList<Skill>();
                    foreach (Skill skill in skillList)
                    {
                        skillcontext.Skills.Remove(skill);
                    }
                    break;
                default:
                    Console.WriteLine("Please enter valid input!");
                    break;
            }

            Console.WriteLine("Skill table after deletion:");
            SkillRepositery.ShowSkillRepositeryTable();

        }
    }
}
