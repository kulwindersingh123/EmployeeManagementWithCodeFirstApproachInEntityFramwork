using EmployeeManagementWithCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach
{
    public class DepartmentRepositery
    {
        public static void ShowDepartmentTable()
        {
            CompanyContext departmentcontext = new CompanyContext();
            List<Department> departmentsLList = departmentcontext.Departments.ToList();
            foreach (Department departmentData in departmentsLList)
            {
                Console.WriteLine(departmentData.Id + " | " + departmentData.Name + " | " + departmentData.IsActive);
            }
        }
        public static void insertDepartment()
        {
            CompanyContext departmentcontext = new CompanyContext();
            
                Console.WriteLine("Enter name of Department:");
                string departmentName = Console.ReadLine();


                Console.WriteLine("Is department active?yes/no");
                string isDepartmentActive = Console.ReadLine();
                if (string.IsNullOrEmpty(departmentName) || string.IsNullOrEmpty(isDepartmentActive))
                {
                    Console.WriteLine("Please enter something!");
                }
                else
                {
                    var insertDepartment = new Department()
                    {
                        
                        Name = departmentName,
                        IsActive = isDepartmentActive,
                    };
                    using (CompanyContext DepartmentContext = new CompanyContext())
                    {
                    try
                    {
                        DepartmentContext.Departments.Add(insertDepartment);
                        DepartmentContext.SaveChanges();
                    }
                    catch (SystemException e) 
                    {
                        Console.WriteLine("Exception occured:"+e.Message);
                    }
                    }
                    Console.WriteLine("Insertion sucessfull");

                }
                Console.WriteLine("Here are elements in Department After insertion:");
                List<Department> departments = departmentcontext.Departments.ToList();
                foreach (Department department in departments)
                {
                    Console.WriteLine("Department_Id={0} | Department_Name:{1} | IsActive:{2}",
                   department.Id, department.Name, department.IsActive);
                }

            


        }

        public static void ReadDepartmentsFromExistingTable()
        {
            CompanyContext departmentcontext = new CompanyContext();
            Console.WriteLine("Enter '1' for read one specific row and '2' all rows:");
            int.TryParse(Console.ReadLine(), out int userChoiceForReadRows);
            switch (userChoiceForReadRows)
            {
                case 1:
                    Department department = new Department();
                    Console.WriteLine("Enter the Department_Id of Department table which you want to read row:");
                    int.TryParse(Console.ReadLine(), out int DepartmentIdForReadSpecificRow);
                    department = departmentcontext.Departments.Find(DepartmentIdForReadSpecificRow);
                    if (department == null)
                    {
                        Console.WriteLine("Row given is not in Department table!");
                    }
                    else
                    {
                        Console.WriteLine(department.Id + " | " + department.Name + " | " + department.IsActive);

                    }

                    break;
                case 2:
                    List<Department> departments = departmentcontext.Departments.ToList();
                    foreach (Department departmentData in departments)
                    {
                        Console.WriteLine(departmentData.Id + " | " + departmentData.Name + " | " + departmentData.IsActive);
                    }
                    break;
                default:
                    Console.WriteLine("Enter valid input.");
                    break;
            }



        }

        public static void UpdateDepartmentTable()
        {
            CompanyContext departmentContext = new CompanyContext();
            Console.WriteLine("Here are rows present in department:");
            DepartmentRepositery.ShowDepartmentTable();
            Console.WriteLine("Enter the Department ID  which you want to update:");
            int.TryParse(Console.ReadLine(), out int departmentIDForUpdation);

            Department department = departmentContext.Departments.Find(departmentIDForUpdation);
            if (department == null)
            {
                Console.WriteLine("There is not any department present with this ID!");
            }
            else
            {
                Console.WriteLine("Enter 1 to update ID of department.\nEnter 2 to update Name of department.\nEnter 3 to update status of department.");
                Console.WriteLine("Note,You can't update Department_ID beacuse that is key in table.");
                int.TryParse(Console.ReadLine(), out int userChoiceForUpdateWhichColoumn);

                switch (userChoiceForUpdateWhichColoumn)
                {
                    case 1:
                        Console.WriteLine("Enter new Id of Department");

                        int.TryParse(Console.ReadLine(), out int departmentId);
                        if (departmentContext.Departments.Find(departmentId) != null)
                        {
                            department.Id = departmentId;
                        }
                        else
                            Console.WriteLine("Forgien key can't be updated!");

                        break;

                    case 2:
                        Console.WriteLine("Enter new name of Department:");
                        string newNameGivenByUser = Console.ReadLine();
                        if (string.IsNullOrEmpty(newNameGivenByUser))
                        {
                            Console.WriteLine("Please enter somthing!");

                        }
                        else
                        {
                            department.Name = newNameGivenByUser;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter new status of Department:");
                        string departmentIsActive = Console.ReadLine();
                        if (string.IsNullOrEmpty(departmentIsActive))
                        {
                            Console.WriteLine("Please enter somthing!");

                        }
                        else
                        {
                            department.IsActive = departmentIsActive;
                        }
                        break;

                }

                departmentContext.SaveChanges();

            }
            Console.WriteLine("After updation Department table is:");
            DepartmentRepositery.ShowDepartmentTable();

        }



        public static void DeteteDeparmentRows()
        {
            CompanyContext departmentContext = new CompanyContext();
            Console.WriteLine("Here are rows present in department:");
            DepartmentRepositery.ShowDepartmentTable();

            Console.WriteLine("press 1 to delete a single row from Department,\n 2 to Delete all rows ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Department Id to delete:");
                    int.TryParse(Console.ReadLine(), out int departmentIdToBeDeleted);
                    Department departmentThatWillDeleted = departmentContext.Departments.Find(departmentIdToBeDeleted);
                    if (departmentThatWillDeleted != null)
                    {
                        departmentContext.Departments.Remove(departmentThatWillDeleted);
                        Console.WriteLine("Row deleted successfully!");
                    }

                    else
                    {
                        Console.WriteLine("There is no record found with id :" + departmentIdToBeDeleted);
                    }
                    departmentContext.SaveChanges();
                    break;
                case 2:
                    List<Department> departmentList = departmentContext.Departments.ToList<Department>();
                    foreach (Department department in departmentList)
                    {
                        departmentContext.Departments.Remove(department);
                    }
                    break;
                default:
                    Console.WriteLine("Please enter valid input!");
                    break;
            }

            Console.WriteLine("Department table after deletion:");

            DepartmentRepositery.ShowDepartmentTable();

        }

    }
}
