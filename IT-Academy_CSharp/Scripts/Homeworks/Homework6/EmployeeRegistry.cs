namespace IT_Academy_CSharp.Homework6;

public static class EmployeeRegistry
{
    private static readonly List<EmployeeBase> _employees = [];

    public static void AddEmployee(EmployeeBase? employee)
    {
        if (employee is not null)
        {
            _employees.Add(employee);
        }
        else
        {
            var errorMessage = "Abort! You are trying to add invalid employee";
            MyUtilities.PrintRedColorMessage(errorMessage);
        }
    }

    public static void ListAllEmployees()
    {
        if (_employees.Count == 0)
        {
            var emptyListErrorMessage = "There are no employees yet!\n" +
                                        "You need to hire some people!";
            MyUtilities.PrintRedColorMessage(emptyListErrorMessage);
        }
        else
        {
            Console.Clear();
            var employeeCountInfo = $"There are {_employees.Count} employees in our company:\n";
            MyUtilities.PrintGreenColorMessage(employeeCountInfo);

            foreach (var employee in _employees)
            {
                employee.GetDetails();
            }
        }
    }

    public static void FindEmployee(string? name)
    {
        var matchEmployees = _employees.FindAll(_ => _.Name!.ToLower() == name?.ToLower());
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