using System.Runtime.InteropServices.JavaScript;

namespace IT_Academy_CSharp.Homework6;

/*
     Описание задачи:

     Разработать систему учета сотрудников в компании,
     включающую их роли, информацию о работе, и возможность управления этими данными.

     Условия:
     Абстрактный класс: EmployeeBase
     Создайте абстрактный класс EmployeeBase с общими свойствами и методом:
     Name (имя сотрудника).
     Position (должность).

     Абстрактный метод GetDetails(), который выводит информацию о сотруднике.
     Производные классы:
     Реализуйте два класса: Manager и Worker, унаследованных от EmployeeBase.
     Добавьте уникальные свойства и реализации метода GetDetails().

     Статический класс: EmployeeRegistry
     Реализуйте статический класс EmployeeRegistry для хранения списка сотрудников и управления ими.
     Методы:
     AddEmployee(EmployeeBase employee) — добавляет сотрудника.
     ListAllEmployees() — выводит всех сотрудников.
     FindEmployee(string name) — ищет сотрудника по имени.

     Вложенный класс:
     В классе Manager создайте вложенный класс Project, который описывает проект, за который отвечает менеджер:
     Поля:
     ProjectName,
     Deadline.
     Метод DisplayProjectInfo() для вывода информации о проекте.
     */

public static class Homework6Main
{
    private static readonly ConsoleKey[] MainMenuValidInputs =
    [
        ConsoleKey.D1, ConsoleKey.NumPad1,
        ConsoleKey.D2, ConsoleKey.NumPad2,
        ConsoleKey.D3, ConsoleKey.NumPad3,
        ConsoleKey.Escape, ConsoleKey.F5
    ];

    public static void RunHomework6()
    {
        Console.CursorVisible = false;
        FillEmployeeList(10);
        var count = 0;
        
        do
        {
            ShowMainMenu(ref count);
        } while (true);
    }

    private static void ShowMainMenu(ref int count)
    {
        var promptText = count == 0 
            ? ConsoleMessages.MainMenuPrompt1 
            : ConsoleMessages.MainMenuPrompt2;
        Console.WriteLine(promptText);
        count++;
        
        var input = Console.ReadKey(true).Key;
        if (Array.Exists(MainMenuValidInputs, _ => _ == input))
        {
            switch (input)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                {
                    EmployeeRegistry.ListAllEmployees();
                    Thread.Sleep(750);
                    return;
                }
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                {
                    CreateEmployeeSwitchCaseLogic();
                    Thread.Sleep(750);
                    return;
                }
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                {
                    FindEmployeeSwitchCaseLogic();
                    Thread.Sleep(750);
                    return;
                }
                case ConsoleKey.F5:
                    Console.Clear();
                    return;
                case ConsoleKey.Escape:
                {
                    ExitProgram();
                    break;
                }
                default:
                    Console.WriteLine("\nInvalid input!\n");
                    break;
            }
        }

        var errorMessage = ConsoleMessages.MainMenuInvalidInputMessage;
        MyUtilities.PrintRedColorMessage(errorMessage);
    }

    private static void FindEmployeeSwitchCaseLogic()
    {
        do
        {
            var promptMessage = "\nPlease enter a name for searching.\n" +
                                "Or enter \"main!\" to return to the main menu.\n";
            Console.WriteLine(promptMessage);

            var input = Console.ReadLine()?.Trim() ?? string.Empty;
            if (input.ToLower().Equals("main!", StringComparison.InvariantCulture))
            {
                Console.Clear();
                break;
            }

            if (MyUtilities.CredentialValidation.IsMatch(input))
            {
                EmployeeRegistry.FindEmployee(input);
                break;
            }

            var errorMessage = "Invalid input! Please use a valid name in search!";
            MyUtilities.PrintRedColorMessage(errorMessage);
        } while (true);
    }

    private static void CreateEmployeeSwitchCaseLogic()
    {
        var newEmployee = CreateNewEmployee();
        EmployeeRegistry.AddEmployee(newEmployee);
        Console.Clear();

        var successMessage = $"New {newEmployee.Position} {newEmployee.Name} has been created. " +
                             $"Detailed information:";
        MyUtilities.PrintGreenColorMessage(successMessage);
        newEmployee.GetDetails();
    }

    private static void FillEmployeeList(int amountToCreate)
    {
        var random = new Random();
        for (var i = 0; i < amountToCreate; i++)
        {
            if (random.Next(0, 4) == 0)
            {
                InstantiateRandomManagers(MyUtilities.MaleFemaleNames50, random);
                continue;
            }

            InstatntiateRandomWorkers(MyUtilities.MaleFemaleNames50, random);
        }

        InstantiateSomeInvalidEmployees();
    }

    private static void InstatntiateRandomWorkers(string[] names, Random random)
    {
        var name = names[random.Next(names.Length)];
        var experience = random.Next(0, 25);
        var shifts = Enum.GetValues(typeof(Enums.Shift));
        var randomShift = (Enums.Shift)shifts.GetValue(random.Next(0, shifts.Length))!;

        var newWorker = new Worker(name, experience, randomShift);
        EmployeeRegistry.AddEmployee(newWorker);
    }

    private static void InstantiateRandomManagers(string[] names, Random random)
    {
        var name = names[random.Next(names.Length)];

        var departments = Enum.GetValues(typeof(Enums.Departments));
        var randomDepartment = (Enums.Departments)departments.GetValue(random.Next(0, departments.Length))!;

        var projects = Enum.GetValues(typeof(Enums.Projects));
        var randomProject = (Enums.Projects)projects.GetValue(random.Next(0, projects.Length))!;

        var daysToAdd = random.Next(0, 180);
        var randomDeadline = DateTime.Today.AddDays(daysToAdd);

        var newManager = new Manager(name, randomDepartment, randomProject, randomDeadline);
        EmployeeRegistry.AddEmployee(newManager);
    }

    private static EmployeeBase CreateNewEmployee()
    {
        var validConsoleInputs = MyUtilities.GetValidNumbericConsoleKeyArray(4, 2);
        Console.Clear();

        do
        {
            Console.WriteLine(ConsoleMessages.AddEmployeePrompt);
            var input = Console.ReadKey(true).Key;

            if (Array.Exists(validConsoleInputs, _ => _ == input))
            {
                return input switch
                {
                    ConsoleKey.D1 or ConsoleKey.NumPad1 => new Worker(),
                    ConsoleKey.D2 or ConsoleKey.NumPad2 => new Manager(),
                };
            }

            var errorMessage = ConsoleMessages.AddNewEmployeeInvalidInputMessage;
            MyUtilities.PrintRedColorMessage(errorMessage);
        } while (true);
    }

    private static void ExitProgram()
    {
        Console.Clear();
        Console.CursorVisible = false;
        var currentCursorPosition = Console.GetCursorPosition();

        for (var i = 3; i >= 0; i--)
        {
            Console.WriteLine($"\n\tExit in {i.ToString()}...");
            if (i != 0)
            {
                Thread.Sleep(1000);
            }

            Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
        }

        MyUtilities.SayByeBye(1);
        Environment.Exit(0);
    }

    private static void InstantiateSomeInvalidEmployees()
    {
        var invalidWorkerName = "Invalid !@#$%^&*() NAME";
        var invalidExperienceValue = -17;
        var brokenWorker = new Worker(invalidWorkerName, invalidExperienceValue, Enums.Shift.Evening);
        EmployeeRegistry.AddEmployee(brokenWorker);

        var invalidManagerName = invalidWorkerName;
        var invalidProjectDeadlineValue = DateTime.MinValue;
        var brokenManager = new Manager(invalidManagerName, Enums.Departments.Madrid,
            Enums.Projects.CS3, invalidProjectDeadlineValue);
        EmployeeRegistry.AddEmployee(brokenManager);
    }
}