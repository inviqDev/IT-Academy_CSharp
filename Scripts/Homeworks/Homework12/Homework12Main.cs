namespace IT_Academy_CSharp.Homeworks.Homework12;

public static class Homework12Main
{
    public static void RunHomework12()
    {
        var usersDataBase = new UsersDataBase();
        ShowMainMenu();

        while (true)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    usersDataBase.AddUserFromConsole();
                    ShowMainMenu();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    usersDataBase.ShowAllUsers();
                    ShowMainMenu();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    ClearConsole();
                    break;
                case ConsoleKey.Escape:
                    MyUtilities.ExitProgram();
                    break;
                default:
                    Console.WriteLine("Invalid key");
                    ShowMainMenu();
                    break;
            }
        }
    }

    private static void ShowMainMenu()
    {
        var startPrompt = "\n\tHello!\n" +
                          "Select an option using digit buttons:\n\n" +
                          "1 - Add a new user\n" +
                          "2 - Show all users\n" +
                          "0 - Clear console\n" +
                          "Esc - Exit program\n";
        MyUtilities.PrintGreenColorMessage(startPrompt);
    }

    private static void ClearConsole()
    {
        Console.Clear();
        Console.CursorVisible = false;

        ShowMainMenu();
    }
}