using System.Globalization;
using System.Text.RegularExpressions;

namespace IT_Academy_CSharp.SideFiles;

public static class MyUtilities
{
    public static readonly Random Random = new();
    
    public static readonly Regex CredentialValidation =
        new(@"^(?:[A-Za-z]+(?:[- ][A-Za-z]+)*|[А-Яа-яЁё]+(?:[- ][А-Яа-яЁё]+)*)$");

    public static readonly TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

    public static readonly string[] NamesBase =
    {
        "Scott", "George", "Sophia", "Daniel", "Steven", "Kenneth", "Isabella", "Amelia", "Eric",
        "Joshua", "Charles", "Larry", "Gary", "Barbara", "Jacob", "Karen", "Michael", "Kevin",
        "Emily", "William", "Ryan", "Christopher", "Harper", "Brian", "Jennifer", "Edward", "James",
        "Elizabeth", "Ronald", "Olivia", "Andrew", "Jeffrey", "Brandon", "Timothy", "Sarah", "Matthew",
        "Stephen", "Linda", "Nicholas", "Ava", "Anthony", "Susan", "Charlotte", "Robert", "Jason",
        "Justin", "David", "Jonathan", "Emma", "Patricia", "Richard", "Mia", "Thomas", "Mark", "Donald",
        "Paul", "Jessica", "John", "Joseph", "Mary"
    };

    public static readonly char[] DefaultSeparatorChars =
    {
        ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')',
        '[', ']', '{', '}', '\"', '\'', '\t', '\n', '\r'
    };

    public static string GetRandomName() => NamesBase[Random.Next(0, NamesBase.Length)];

    public static void PrintRedColorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{message}\n");
        Console.ResetColor();
    }

    public static void PrintGreenColorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{message}\n");
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
        PrintGreenColorMessage("\n\tBye, Bye!");
        Thread.Sleep(timeInMilliseconds);
    }

    public static void ExitProgram()
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

    /// <summary>
    /// Returns an array of ConsoleKey values representing valid numeric digit keys
    /// (both main keyboard D0–D9 and NumPad0–NumPad9) up to the specified maximum digit.
    /// </summary>
    /// <param name="lastAllowedDigit">
    /// The highest digit (1 through 9) to include in the returned keys.
    /// For example, lastAllowedDigit = 4 includes:
    /// ConsoleKeys.D1, ConsoleKeys.NumPad1, …, ConsoleKeys.D4, ConsoleKeys.NumPad4.
    /// </param>
    /// <returns>
    /// An array of ConsoleKey representing the allowed numeric inputs.
    /// </returns>
    public static ConsoleKey[] GetAllowedNumericKeys(int lastAllowedDigit)
    {
        ConsoleKey[] validInputButtons =
        [
            ConsoleKey.D1, ConsoleKey.NumPad1, // if lastAllowedDigit = 1
            ConsoleKey.D2, ConsoleKey.NumPad2, // if lastAllowedDigit = 2
            ConsoleKey.D3, ConsoleKey.NumPad3, // if lastAllowedDigit = 3
            ConsoleKey.D4, ConsoleKey.NumPad4, // if lastAllowedDigit = 4
            ConsoleKey.D5, ConsoleKey.NumPad5, // if lastAllowedDigit = 5
            ConsoleKey.D6, ConsoleKey.NumPad6, // if lastAllowedDigit = 6
            ConsoleKey.D7, ConsoleKey.NumPad7, // if lastAllowedDigit = 7
            ConsoleKey.D8, ConsoleKey.NumPad8, // if lastAllowedDigit = 8
            ConsoleKey.D9, ConsoleKey.NumPad9, // if lastAllowedDigit = 9
            ConsoleKey.D0, ConsoleKey.NumPad0, // if lastAllowedDigit = 10
        ];

        // ConsoleKeys need to be selected as pairs => value[0] and value[1] have the same logic, etc.
        // To include all buttons <lastAllowedDigit> must be multiplied by 2
        lastAllowedDigit *= 2;
        return validInputButtons[..lastAllowedDigit];
    }
}