using IT_Academy_CSharp.Homeworks.Homework6.Enums;
using IT_Academy_CSharp.SideFiles;

namespace IT_Academy_CSharp.Homeworks.Homework6;

public class Manager : EmployeeBase
{
    private Project _currentProject;
    public Departments Department { get; set; }

    public Manager()
    {
        Position = Positions.Manager;
        Department = GetManagerDepartment();
        _currentProject = new Project(this);
    }

    public Manager(string? name, Departments department,
        Projects currentProject, DateTime deadline) : base(name)
    {
        Position = Positions.Manager;
        Department = department;

        _currentProject = new Project(this, currentProject, deadline)
        {
            CurrentProject = currentProject,
            ProjectDeadline = deadline
        };
    }

    public override void GetDetails()
    {
        var baseInfo = GetEmployeeBaseInfo();
        var uniqueInfo = GetManagerUniqueInfo();
        MyUtilities.PrintGreenColorMessage($"{baseInfo} | {uniqueInfo}");
    }

    private Departments GetManagerDepartment()
    {
        var menuOptionsAmount = 4;
        var validInputButtons = MyUtilities.GetAllowedNumericKeys(menuOptionsAmount);

        do
        {
            Console.WriteLine(ConsoleMessages.ManagerDepartmentSelectionPrompt);
            var input = Console.ReadKey(true).Key;

            if (Array.Exists(validInputButtons, _ => _ == input))
            {
                var department = input switch
                {
                    ConsoleKey.D1 or ConsoleKey.NumPad1 => Departments.Moscow,
                    ConsoleKey.D2 or ConsoleKey.NumPad2 => Departments.London,
                    ConsoleKey.D3 or ConsoleKey.NumPad3 => Departments.Madrid,
                    ConsoleKey.D4 or ConsoleKey.NumPad4 => Departments.Warsaw,
                };

                var consoleMessage = $"\n{Name}'s department is {department}\n";
                MyUtilities.PrintGreenColorMessage(consoleMessage);
                return department;
            }

            var errorMessage = ConsoleMessages.ManagerDepartmentSelectionInvalidInputMessage;
            MyUtilities.PrintRedColorMessage(errorMessage);
        } while (true);
    }

    private string GetManagerUniqueInfo()
    {
        var managerProjectInfo = _currentProject.GetProjectInfo();
        return $"Department: {Department} | {managerProjectInfo}";
    }


    private class Project()
    {
        private readonly Manager? _projectOwner;
        private DateTime _projectDeadline;

        public Projects CurrentProject { get; set; }

        public DateTime ProjectDeadline
        {
            get => _projectDeadline;
            set => _projectDeadline = value > DateTime.Today ? value : DateTime.Today;
        }

        internal Project(Manager projectOwner) : this()
        {
            _projectOwner = projectOwner;
            CurrentProject = GetManagerProject();
            ProjectDeadline = GetManagerProjectDeadline();
        }

        internal Project(Manager projectOwner, Projects currentProject, DateTime deadline) : this()
        {
            _projectOwner = projectOwner;
            CurrentProject = currentProject;
            ProjectDeadline = deadline;
        }

        private DateTime GetManagerProjectDeadline()
        {
            do
            {
                Console.WriteLine("Please enter the number of days required to complete the current project: ");
                var inputIsValid = int.TryParse(Console.ReadLine()?.Trim(), out var numberOfDays);
                if (inputIsValid && numberOfDays >= 0)
                {
                    var deadline = numberOfDays is > 0 and < 365242 // 365242 days = 1000 years
                        ? DateTime.Today.AddDays(numberOfDays)
                        : DateTime.Today;

                    var consoleMessage = numberOfDays is > 0 and < 365242
                        ? $"\n{CurrentProject} deadline is {deadline.ToLongDateString()}\n"
                        : $"Invalid input! Cannot set the project deadline in {numberOfDays} days.\n" +
                          $"Deadline \"{DateTime.Today}\" is set as a default value.";

                    MyUtilities.PrintGreenColorMessage(consoleMessage);
                    return deadline;
                }

                var errorMessage = "Invalid input! Please enter a whole number >= 0";
                MyUtilities.PrintRedColorMessage(errorMessage);
            } while (true);
        }

        private Projects GetManagerProject()
        {
            var menuOptionsAmount = 4;
            var validInputButtons = MyUtilities.GetAllowedNumericKeys(menuOptionsAmount);
            do
            {
                Console.WriteLine(ConsoleMessages.ManagerProjectSelectionPrompt);
                var input = Console.ReadKey(true).Key;

                if (Array.Exists(validInputButtons, _ => _ == input))
                {
                    var currentProject = input switch
                    {
                        ConsoleKey.D1 or ConsoleKey.NumPad1 => Projects.Doom5,
                        ConsoleKey.D2 or ConsoleKey.NumPad2 => Projects.GTA7,
                        ConsoleKey.D3 or ConsoleKey.NumPad3 => Projects.CS3,
                        ConsoleKey.D4 or ConsoleKey.NumPad4 => Projects.DOTA4,
                    };

                    var consoleMessage = $"{_projectOwner?.Name}'s current project is {currentProject}\n";
                    MyUtilities.PrintGreenColorMessage(consoleMessage);
                    return currentProject;
                }

                var errorMessage = ConsoleMessages.ManagerProjectSelectionInvalidInputMessage;
                MyUtilities.PrintRedColorMessage(errorMessage);
            } while (true);
        }

        public string GetProjectInfo()
        {
            return $"Project: {CurrentProject.ToString()} | " +
                   $"Deadline: {ProjectDeadline.ToLongDateString()}\n";
        }
    }
}