namespace IT_Academy_CSharp;

public static class MyUtilities
{
    public static void PrintRedColorMessage(string? message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
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
        var timeInMiliseconds = timeInSeconds * 1000;
        Thread.Sleep(timeInMiliseconds); 
        
        Console.Clear();
        PrintGreenColorMessage("\n\tBye, Bye!\n");
    }
}