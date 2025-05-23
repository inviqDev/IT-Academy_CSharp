using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IT_Academy_CSharp;

public static class MyUtilities
{
    public static readonly Regex CredentialValidation =
        new(@"^(?:[A-Za-z]+(?:[- ][A-Za-z]+)*|[А-Яа-яЁё]+(?:[- ][А-Яа-яЁё]+)*)$");

    public static readonly TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

    public static readonly StringBuilder StrBuilder = new();

    public static readonly string[] MaleFemaleNames50 =
    {
        "Scott", "George", "Sophia", "Daniel", "Steven", "Kenneth", "Isabella", "Amelia", "Eric",
        "Joshua", "Charles", "Larry", "Gary", "Barbara", "Jacob", "Karen", "Michael", "Kevin",
        "Emily", "William", "Ryan", "Christopher", "Harper", "Brian", "Jennifer", "Edward", "James",
        "Elizabeth", "Ronald", "Olivia", "Andrew", "Jeffrey", "Brandon", "Timothy", "Sarah", "Matthew",
        "Stephen", "Linda", "Nicholas", "Ava", "Anthony", "Susan", "Charlotte", "Robert", "Jason",
        "Justin", "David", "Jonathan", "Emma", "Patricia", "Richard", "Mia", "Thomas", "Mark", "Donald",
        "Paul", "Jessica", "John", "Joseph", "Mary"
    };

    public static void PrintRedColorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ResetColor();
    }

    public static void PrintGreenColorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintSeparationLine(char separationSymbol)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        var symbolsAmount = Console.WindowWidth;
        var separationLine = new string(separationSymbol, symbolsAmount);
        Console.WriteLine($"\n{separationLine}\n");

        Console.ResetColor();
    }

    public static void PlaySadMelody()
    {
        var duration = 275;
        var tones = new[] { 300, 285, 270, 255, 240 };
        for (var i = 0; i < tones.Length; i++)
        {
            Console.Beep(tones[i], duration);
            if (i == tones.Length - 2)
            {
                duration = 975;
            }
        }
    }

    public static void SayByeBye(int timeInSeconds)
    {
        var timeInMilliseconds = timeInSeconds * 1000;
        Thread.Sleep(timeInMilliseconds);

        Console.Clear();
        PrintGreenColorMessage("\tBye, Bye!");
        Thread.Sleep(timeInMilliseconds);
    }

    public static ConsoleKey[] GetValidNumbericConsoleKeyArray(int validButtonsAmount, int lastNumberButton)
    {
        ConsoleKey[] validInputButtons =
        [
            ConsoleKey.D1, ConsoleKey.NumPad1,
            ConsoleKey.D2, ConsoleKey.NumPad2,
            ConsoleKey.D3, ConsoleKey.NumPad3,
            ConsoleKey.D4, ConsoleKey.NumPad4,
            ConsoleKey.D5, ConsoleKey.NumPad5,
            ConsoleKey.D6, ConsoleKey.NumPad6,
            ConsoleKey.D7, ConsoleKey.NumPad7,
            ConsoleKey.D8, ConsoleKey.NumPad8,
            ConsoleKey.D9, ConsoleKey.NumPad9,
            ConsoleKey.D0, ConsoleKey.NumPad0,
        ];

        // ConsoleKeys need to be selected as pairs => value[0] and value[1] have the same logic, etc.
        // To include all buttons <lastNumberButton> must be multiplied by 2
        lastNumberButton *= 2;
        return validInputButtons[..lastNumberButton];
    }
}