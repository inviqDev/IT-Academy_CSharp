namespace IT_Academy_CSharp.Homework6;

public abstract class EmployeeBase
{
    public string? Name { get; private set; }

    public Positions Position { get; private protected set; }

    private protected EmployeeBase()
    {
        Name = GetNewEmployeeName();
    }

    private protected EmployeeBase(string? name)
    {
        Name = SetNewEmployeeName(name!);
    }

    private static string GetNewEmployeeName()
    {
        do
        {
            Console.WriteLine("\nEnter a new employee name: ");
            var input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            var matchRegexPattern = MyUtilities.CredentialValidation.IsMatch(input);

            if (!matchRegexPattern)
            {
                var errorMessage = "Invalid input! Please enter a valid worker name!";
                MyUtilities.PrintRedColorMessage(errorMessage);
                continue;
            }

            var formattedName = MyUtilities.TextInfo.ToTitleCase(input);
            var workerNameMessage = $"Worker's name is set as {formattedName}";
            MyUtilities.PrintGreenColorMessage(workerNameMessage);

            return formattedName;
        } while (true);
    }

    private string SetNewEmployeeName(string newName)
    {
        return MyUtilities.CredentialValidation.IsMatch(newName) ? newName : "default name";
    }

    public abstract void GetDetails();

    private protected string GetEmployeeBaseInfo()
    {
        return $"Name: {Name} | Position: {Position}";
    }
}