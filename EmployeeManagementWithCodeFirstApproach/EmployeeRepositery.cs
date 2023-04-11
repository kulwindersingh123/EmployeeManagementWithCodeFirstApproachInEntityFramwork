using EmployeeManagementWithCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWithCodeFirstApproach
{
    public  class EmployeeRepositery
    {
        public static void ShowEmployeeTable()
        {
            CompanyContext employeeContext = new CompanyContext();
            List<Employee> employeeList = employeeContext.Employees.ToList();
            foreach (Employee employeeData in employeeList)
            {
                Console.WriteLine(employeeData.Id + " | " + employeeData.Name + " | " + employeeData.Email + " | " + employeeData.Phone + " | " + employeeData.DepartmentId + " | " + employeeData.IsActive);
            }
        }
        public static void InsertNewEmployeeInComapnyTable()
        {
            CompanyContext employeeContext = new CompanyContext();

            
                Console.WriteLine("Enter the Name of Employee:");
                string employeeNameForInsertion = Console.ReadLine();

                Console.WriteLine("Enter yes/no if Employee ia active or not:");
                string employeeIsActive = Console.ReadLine();

                Console.WriteLine("Enter the Email of Employee:");
                string employeeEmailForInsertion = Console.ReadLine();

                Console.WriteLine("Enter Employee phone:");
                string employeePhoneForInsertion = Console.ReadLine();

                Console.WriteLine("Enter Employee DepartmentId:");
                int.TryParse(Console.ReadLine(), out int employeeDepartmentIdForInsertion);
                if (employeeContext.Departments.Find(employeeDepartmentIdForInsertion) == null)
                {
                    Console.WriteLine("Sorry,This Deptarment ID not present in Department table");
                }


                Console.WriteLine("Is Employee active?yes/no");
                string isEmployeeActive = Console.ReadLine();
                if (string.IsNullOrEmpty(employeeNameForInsertion) || string.IsNullOrEmpty(employeeIsActive) || string.IsNullOrEmpty(employeeEmailForInsertion) || string.IsNullOrEmpty(employeePhoneForInsertion))
                {
                    Console.WriteLine("Sorry,string is empty!");
                }
                else
                {
                    var insertEmployee = new Employee()
                    {
                        //Id = employeeIDForInsertion,
                        Name = employeeNameForInsertion,
                        IsActive = employeeIsActive,
                        Email = employeeEmailForInsertion,
                        Phone = employeePhoneForInsertion,
                        DepartmentId = employeeDepartmentIdForInsertion,
                    };
                    using (CompanyContext EmployeeContext = new CompanyContext())
                    {
                    try
                    {
                        EmployeeContext.Employees.Add(insertEmployee);
                        EmployeeContext.SaveChanges();
                    }
                    catch (SystemException e) 
                    {
                        Console.WriteLine("Exception occured:"+e.Message);
                    }
                    }
                }
                Console.WriteLine("Insertion successfull");
            
            Console.WriteLine("Here are elements in Employee After insertion:");
            EmployeeRepositery.ShowEmployeeTable();

        }
        public static void ReadEmployeesThatExistInCompanyTable()
        {
            CompanyContext employeeContext = new CompanyContext();
            Console.WriteLine("Enter '1' for read one specific row and '2' all rows:");
            int.TryParse(Console.ReadLine(), out int userChoiceForReadRows);
            switch (userChoiceForReadRows)
            {
                case 1:
                    Employee employee = new Employee();
                    Console.WriteLine("Enter the EmployeeID of Employee which you want to read row:");
                    int.TryParse(Console.ReadLine(), out int emploeeIDForReadSpecificRow);
                    employee = employeeContext.Employees.Find(emploeeIDForReadSpecificRow);
                    if (emploeeIDForReadSpecificRow == null)
                    {
                        Console.WriteLine("Row of given Emplyee is not in table!");
                    }
                    else
                    {
                        Console.WriteLine(employee.Id + " | " + employee.Name + " | " + employee.Email + " | " + employee.Phone + " | " + employee.DepartmentId + " | " + employee.IsActive);
                    }

                    break;
                case 2:
                    EmployeeRepositery.ShowEmployeeTable();
                    break;
                default:
                    Console.WriteLine("Enter valid input.");
                    break;
            }

        }
        public static void UpdateEmployeeINCompanyTable()
        {
            CompanyContext employeeContext = new CompanyContext();
            Console.WriteLine("Here are rows present in Employee Table:");
            EmployeeRepositery.ShowEmployeeTable();
            Console.WriteLine("Enter the EmployeeID of employee of which you want to update:");
            int.TryParse(Console.ReadLine(), out int employeeIDForUpdation);

            Employee employee = employeeContext.Employees.Find(employeeIDForUpdation);
            if (employee == null)
            {
                Console.WriteLine("There is not any employee present with this ID!");
            }
            else
            {
                Console.WriteLine("Enter the coloumn name of employee with given ID which you want to update:");
                Console.WriteLine("There are four coloumn which you can update-\n1.Employee_Name\n2.Employee_Email\n3.Employee_Phone\n4.IsActive");
                Console.WriteLine("Note,You can't update Employee_ID and Employee_DepartemntID beacuse these are keys in table.");
                string userChoiceForUpdateWhichColoumn = Console.ReadLine();
                if (string.IsNullOrEmpty(userChoiceForUpdateWhichColoumn))
                {
                    Console.WriteLine("Please enter somthing!");
                }
                else
                {
                    switch (userChoiceForUpdateWhichColoumn)
                    {
                        case "Employee_Name":
                            Console.WriteLine("Enter new name of Employee:");
                            string newNameGivenByUser = Console.ReadLine();
                            if (string.IsNullOrEmpty(newNameGivenByUser))
                            {
                                Console.WriteLine("Please enter somthing!");

                            }
                            else
                            {
                                employee.Name = newNameGivenByUser;
                            }
                            break;

                        case "Employee_Email":
                            Console.WriteLine("Enter new Email of Employee:");
                            string newEmailGivenByUser = Console.ReadLine();
                            if (string.IsNullOrEmpty(newEmailGivenByUser))
                            {
                                Console.WriteLine("Please enter somthing!");

                            }
                            else
                            {
                                employee.Email = newEmailGivenByUser;
                            }
                            break;

                        case "Employee_Phone":
                            Console.WriteLine("Enter new phone of Employee:");
                            string newPhoneGivenByUser = Console.ReadLine();
                            if (string.IsNullOrEmpty(newPhoneGivenByUser))
                            {
                                Console.WriteLine("Please enter somthing!");

                            }
                            else
                            {
                                employee.Phone = newPhoneGivenByUser;
                            }
                            break;

                        case "Deparment_Id":
                            Console.WriteLine("Enter new  DepartmentId of employee");

                            int.TryParse(Console.ReadLine(), out int departmentId);
                            if (employeeContext.Departments.Find(departmentId) != null)
                            {
                                employee.DepartmentId = departmentId;
                            }
                            else
                                Console.WriteLine("Forgien key can't be updated!");

                            break;

                        case "IsActive":
                            Console.WriteLine("Enter new status of Employee:");
                            string employeeIsActive = Console.ReadLine();
                            if (string.IsNullOrEmpty(employeeIsActive))
                            {
                                Console.WriteLine("Please enter somthing!");

                            }
                            else
                            {
                                employee.IsActive = employeeIsActive;
                            }
                            break;
                        case "Employee_Id":
                            Console.WriteLine("Enter new  DepartmentId of employee");

                            int.TryParse(Console.ReadLine(), out int emlpoyeeId);
                            if (employeeContext.Departments.Find(emlpoyeeId) != null)
                            {
                                employee.DepartmentId = emlpoyeeId;
                            }
                            else
                                Console.WriteLine("Primary key can't be updated!");
                            break;




                    }

                    employeeContext.SaveChanges();

                }
                Console.WriteLine("After updation employee table is:");
                EmployeeRepositery.ShowEmployeeTable();
            }

        }

        public static void DeteteEmployeeRows()
        {
            CompanyContext employeeContext = new CompanyContext();

            Console.WriteLine("press 1 to delete a single record from Employees,\n 2 to Delete all records ");

            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Employee Id to delete:");
                    int.TryParse(Console.ReadLine(), out int employeeIdToBeDeleted);
                    Employee emplyeeThatWillDeleted = employeeContext.Employees.Find(employeeIdToBeDeleted);
                    if (emplyeeThatWillDeleted != null)
                    {
                        employeeContext.Employees.Remove(emplyeeThatWillDeleted);
                        Console.WriteLine("Row deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("There is no record found with id :" + employeeIdToBeDeleted);
                    }
                    employeeContext.SaveChanges();
                    break;
                case 2:
                    List<Employee> employeeList =
                   employeeContext.Employees.ToList<Employee>();
                    foreach (Employee employee in employeeList)
                    {
                        employeeContext.Employees.Remove(employee);
                    }
                    break;
                default:
                    Console.WriteLine("Please enter valid input!");
                    break;
            }

            Console.WriteLine("Employee table after deletion:");
            EmployeeRepositery.ShowEmployeeTable();

        }
    }
}
