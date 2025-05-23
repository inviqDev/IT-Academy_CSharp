namespace IT_Academy_CSharp.Homework6;

public static class ConsoleMessages
{
    public static readonly string MainMenuPrompt1 =
        """
            Hello! 🌺
        Press a key to choose an option:
        1 – Show all employees
        2 - Add a new employee
        3 – Find an employee by name
        F5 – Clear screen and return to main menu
        Esc - Close this amazing program
        """;

    public static readonly string MainMenuPrompt2 =
        """
        Press a key to choose an option:
        1 – Show all employees
        2 - Add a new employee
        3 – Find an employee by name
        F5 – Clear screen and return to main menu
        Esc - Close this amazing program.
        """;

    public static readonly string MainMenuInvalidInputMessage =
        """
            Invalid choice!
        Please press one of the following keys:
        1 – Show all employees
        2 – Add a new employee
        3 – Find an employee by name
        F5 – Clear screen and return to main menu
        Esc – Exit the program
        """;

    public static readonly string WorkerShiftSelectionPrompt =
        """
        Please select a shift for the worker.
        Press one of the following keys:
        1 – Day shift
        2 – Evening shift
        3 – Night shift
        """;

    public static readonly string WorkerShiftSelectionInvalidInputMessage =
        """
        Invalid shift selection for the worker!
        Please press one of the following keys:
        1 – Day shift
        2 – Evening shift
        3 – Night shift
        """;

    public static readonly string ManagerDepartmentSelectionPrompt =
        """
        Please select a department for the manager.
        Press one of the following keys:
        1 – Moscow
        2 – London
        3 – Madrid
        4 – Warsaw
        """;

    public static readonly string ManagerDepartmentSelectionInvalidInputMessage =
        """
        \nInvalid department selection for the manager!
        Please press one of the following keys:
        1 – Moscow
        2 – London
        3 – Madrid
        4 – Warsaw
        """;

    public static readonly string ManagerProjectSelectionPrompt =
        """
        Please select a project for the manager.
        Press one of the following keys:
        1 – Doom5
        2 – GTA7
        3 – CS3
        4 – DOTA4
        """;

    public static readonly string ManagerProjectSelectionInvalidInputMessage =
        """
        Invalid project selection for the manager!
        Press one of the following keys:
        1 – Doom5
        2 – GTA7
        3 – CS3
        4 – DOTA4
        """;

    public static readonly string AddEmployeePrompt =
        """
        Select a type of a new employee:
        1 – Worker
        2 – Manager
        """;

    public static readonly string AddNewEmployeeInvalidInputMessage =
        """
        Invalid employee type selection!
        Press one of the following keys:
        1 – Worker
        2 – Manager
        """;
}