using IT_Academy_CSharp.SideFiles;

namespace IT_Academy_CSharp.Homeworks.Homework6;

public static class EmployeeRegistry
{
    private static readonly List<EmployeeBase> Employees = [];

    public static void AddEmployee(EmployeeBase? employee)
    {
        if (employee is not null)
        {
            Employees.Add(employee);
        }
        else
        {
            var errorMessage = "Abort! You are trying to add invalid employee";
            MyUtilities.PrintRedColorMessage(errorMessage);
        }
    }

    public static void ListAllEmployees()
    {
        if (Employees.Count == 0)
        {
            var emptyListErrorMessage = "There are no employees yet!\n" +
                                        "You need to hire some people!";
            MyUtilities.PrintRedColorMessage(emptyListErrorMessage);
        }
        else
        {
            Console.Clear();
            var employeeCountInfo = $"There are {Employees.Count} employees in our company:\n";
            MyUtilities.PrintGreenColorMessage(employeeCountInfo);

            foreach (var employee in Employees)
            {
                employee.GetDetails();
            }
        }
    }

    public static void FindEmployee(string? name)
    {
        var matchEmployees = Employees.FindAll(_ => _.Name!.ToLower() == name?.ToLower());
        if (matchEmployees.Count > 0)
        {
            var additionalInfo = matchEmployees.Count == 1
                ? $"{matchEmployees[0].Position} \"{matchEmployees[0].Name}\" was found.\n" +
                  $"See detailed information below:"
                : $"{matchEmployees.Count} employees with \"{name}\" name were found.\n" +
                  $"See detailed information below:";
            MyUtilities.PrintGreenColorMessage(additionalInfo);

            foreach (var employee in matchEmployees)
            {
                employee.GetDetails();
            }
        }
        else
        {
            Console.WriteLine($"\nThere is no employee with name \"{name}\" in our company!\n");
        }
    }
}