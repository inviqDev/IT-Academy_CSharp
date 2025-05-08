namespace IT_Academy_CSharp;

public static class MyUtilities
{
    public static void PrintErrorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ResetColor();
    }

    public static void PrintValidMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{message}\n");
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
}