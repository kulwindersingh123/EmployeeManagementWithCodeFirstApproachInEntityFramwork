using EmployeeManagementWithCodeFirstApproach;

public class Program
{
    public static int userChoiceForOperation()
    {
        Console.WriteLine("Enter 'c' to create a new row in table.\nEnter 'r' to read rows in table.\nEnter 'u' to update rows in table.\nEnter 'd' to delelte rows in table.");
        //Console.WriteLine("Press 0 to return to menu.");
        char.TryParse(Console.ReadLine(), out char userInputForOPerationOnSkillTable);
        return userInputForOPerationOnSkillTable;
    }

    public static void Main(string[] args)
    {

        CompanyContext modelContext = new CompanyContext();
        Console.WriteLine("Enter the Table in which you want to perform CRUD operations:");
        Console.WriteLine("Enter 1 for Department.\nEnter 2 for Employee.\nEnter 3 for Skills and\n Enter 4 for EmployeeSkill.");
        int.TryParse(Console.ReadLine(), out int userOptionToSelectTable);
        switch (userOptionToSelectTable)
        {
            case 1:
                int userInputForOPerationOnGivenTable = Program.userChoiceForOperation();
                switch (userInputForOPerationOnGivenTable)
                {
                    case 'c':
                        DepartmentRepositery.insertDepartment();
                        break;
                    case 'r':
                        DepartmentRepositery.ReadDepartmentsFromExistingTable();
                        break;
                    case 'u':
                        DepartmentRepositery.UpdateDepartmentTable();
                        break;
                    case 'd':
                        DepartmentRepositery.DeteteDeparmentRows();
                        break;
                    default:
                        Console.WriteLine("please enter valid input!");
                        break;
                }

                break;
            case 2:
                int userInputForOPerationOnEmployeeTable = Program.userChoiceForOperation();
                switch (userInputForOPerationOnEmployeeTable)
                {
                    case 'c':
                        EmployeeRepositery.InsertNewEmployeeInComapnyTable();
                        break;
                    case 'r':
                        EmployeeRepositery.ReadEmployeesThatExistInCompanyTable();
                        break;
                    case 'u':
                        EmployeeRepositery.UpdateEmployeeINCompanyTable();
                        break;
                    case 'd':
                        EmployeeRepositery.DeteteEmployeeRows();
                        break;
                    
                    default:
                        Console.WriteLine("please enter valid input!");
                        break;
                }

                break;
            case 3:
                int userInputForOPerationOnSkillTable = Program.userChoiceForOperation();
                switch (userInputForOPerationOnSkillTable)
                {
                    case 'c':
                        SkillRepositery.insertSkill();
                        break;
                    case 'r':
                        SkillRepositery.ReadSkillFromExistingTable();
                        break;
                    case 'u':
                        SkillRepositery.UpdateSkillTable();
                        break;
                    case 'd':
                        SkillRepositery.DeteteskillRows();
                        break;
                    
                    default:
                        Console.WriteLine("please enter valid input!");
                        break;
                }

                break;

            case 4:
                int userInputForOPerationOnEmploeeSkillTable = Program.userChoiceForOperation();
                switch (userInputForOPerationOnEmploeeSkillTable)
                {
                    case 'c':
                        EmployeeSkillRepositery.InsertEmployeeSkill();
                        break;
                    case 'r':
                        EmployeeSkillRepositery.ReadEmployeeSkillFormExistingTable();
                        break;
                    case 'u':
                        Console.WriteLine("Keys can't be updated!");
                        break;
                    case 'd':
                        EmployeeSkillRepositery.DeteteEmployeeSkillRows();
                        break;
                   
                    default:
                        Console.WriteLine("please enter valid input!");
                        break;
                }

                break;



        }
    }

}