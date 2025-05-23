namespace IT_Academy_CSharp.Homework6;

public class Manager : EmployeeBase
{
    private Project _currentProject;
    private Enums.Departments _currentDepartment;

    public Enums.Departments Department { get; set; }

    public Manager()
    {
        Position = Enums.Positions.Manager;
        _currentProject = new Project(this);
        Department = GetManagerDepartment();
    }

    public Manager(string? name, Enums.Departments department,
        Enums.Projects currentProject, DateTime deadline) : base(name)
    {
        Position = Enums.Positions.Manager;
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

    private Enums.Departments GetManagerDepartment()
    {
        var validInputButtons = MyUtilities.GetValidNumbericConsoleKeyArray(4, 4);

        do
        {
            Console.WriteLine(ConsoleMessages.ManagerDepartmentSelectionPrompt);
            var input = Console.ReadKey(true).Key;

            if (Array.Exists(validInputButtons, _ => _ == input))
            {
                var department = input switch
                {
                    ConsoleKey.D1 or ConsoleKey.NumPad1 => Enums.Departments.Moscow,
                    ConsoleKey.D2 or ConsoleKey.NumPad2 => Enums.Departments.London,
                    ConsoleKey.D3 or ConsoleKey.NumPad3 => Enums.Departments.Madrid,
                    ConsoleKey.D4 or ConsoleKey.NumPad4 => Enums.Departments.Warsaw,
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

        public Enums.Projects CurrentProject { get; set; }

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

        internal Project(Manager projectOwner, Enums.Projects currentProject, DateTime deadline) : this()
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

        private Enums.Projects GetManagerProject()
        {
            var validInputButtons = MyUtilities.GetValidNumbericConsoleKeyArray(4, 4);
            do
            {
                Console.WriteLine(ConsoleMessages.ManagerProjectSelectionPrompt);
                var input = Console.ReadKey(true).Key;

                if (Array.Exists(validInputButtons, _ => _ == input))
                {
                    var currentProject = input switch
                    {
                        ConsoleKey.D1 or ConsoleKey.NumPad1 => Enums.Projects.Doom5,
                        ConsoleKey.D2 or ConsoleKey.NumPad2 => Enums.Projects.GTA7,
                        ConsoleKey.D3 or ConsoleKey.NumPad3 => Enums.Projects.CS3,
                        ConsoleKey.D4 or ConsoleKey.NumPad4 => Enums.Projects.DOTA4,
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