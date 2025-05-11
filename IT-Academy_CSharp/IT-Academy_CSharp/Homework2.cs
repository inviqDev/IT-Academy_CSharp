namespace IT_Academy_CSharp;

public static class Homework2
{
    public static void RunHomeWork2()
    {
        RunHomework2Part1();
        MyUtilities.PrintSeparationLine('-');
        RunHomework2Part2();
        MyUtilities.PrintSeparationLine('-');
        Console.WriteLine("Bye, Bye!");
    }

    private static void RunHomework2Part1()
    {
        Console.WriteLine("\tЗадание №2.1\n");

        var promptMessage = "Введите Ваше имя: ";
        var userName = GetValidUserName(promptMessage);

        promptMessage = "Введите Ваш возраст: ";
        var userAge = GetValidUserAge(promptMessage);

        promptMessage = "Введите Ваш рост (в метрах): ";
        var userHeight = GetValidUserHeight(promptMessage);

        var taskResultOutputMessage = $"Привет, {userName}!\n" +
                                      $"\tВаш возраст: {userAge} лет.\n" +
                                      $"\t\tВаш рост: {userHeight:F2} м.";
        MyUtilities.PrintValidMessage(taskResultOutputMessage);
    }

    private static string GetValidUserName(string promptMessage)
    {
        do
        {
            Console.Write(promptMessage);
            var userInput = Console.ReadLine()?.Trim() ?? string.Empty;
            if (userInput != string.Empty)
            {
                return userInput;
            }

            var errorDescription = "Неверный формат ввода!\n" +
                                   "Пожалуйста, введите имя заново.";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (true);
    }
    
    private static int GetValidUserAge(string? promptMessage)
    {
        do
        {
            Console.Write(promptMessage);
            var userInput = Console.ReadLine()?.Trim() ?? string.Empty;
            var isValidInput = int.TryParse(userInput, out var userAge);
            if (isValidInput && userAge > 0)
            {
                return userAge;
            }

            var errorDescription = !isValidInput
                ? "Неверный формат ввода.\nПожалуйста, введите целое число."
                : "Возраст не может быть отрицательным.\nПожалуйста, введите число > 0 и < 125.";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (true);
    }

    private static double GetValidUserHeight(string? promptMessage)
    {
        do
        {
            Console.Write(promptMessage);
            var userInput = Console.ReadLine()?.Trim().Replace(',', '.') ?? string.Empty;
            var isValidInput = double.TryParse(userInput, out var userHeight);
            if (isValidInput && userHeight is > 0 and < 3)
            {
                return userHeight;
            }

            var errorDescription = !isValidInput
                ? "Неверный формат ввода.\nПожалуйста, введите целое или дробное число (например, 1.64 или 1,64)"
                : "Рост не может быть равен 0 или быть отрицательным.\nПожалуйста, введите число > 0 и < 3.";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (true);
    }

    private static void RunHomework2Part2()
    {
        Console.WriteLine("\tЗадание №2.2\n");

        var promptMessage = "Введите первое число: ";
        var firstValue = GetValidValue(promptMessage);

        promptMessage = "Введите второе число: ";
        var secondValue = GetValidValue(promptMessage);

        Console.ForegroundColor = ConsoleColor.Green;
        PrintHomework2Part2Result(firstValue, secondValue);
        Console.ResetColor();
    }

    private static void PrintHomework2Part2Result(double firstValue, double secondValue)
    {
        Console.WriteLine($"{firstValue} + {secondValue} = {firstValue + secondValue}\n" +
                          $"{firstValue} - {secondValue} = {firstValue - secondValue}\n" +
                          $"{firstValue} * {secondValue} = {firstValue * secondValue}");

        if (secondValue != 0)
        {
            Console.WriteLine($"{firstValue} / {secondValue} = {firstValue / secondValue}");
        }
        else
        {
            var errorDescription = $"{firstValue} / {secondValue} : На ноль делить нельзя!";
            MyUtilities.PrintErrorMessage(errorDescription);
        }
    }

    private static double GetValidValue(string promptMessage)
    {
        do
        {
            Console.Write(promptMessage);
            var userInput = Console.ReadLine()?.Trim().Replace(',', '.') ?? string.Empty;
            if (double.TryParse(userInput, out var validValue))
            {
                return validValue;
            }

            var errorDescription = "Неверный формат ввода! Пожалуйста, введите целое или дробное число.\n" +
                                   "Разделитель для дробного числа: «,» или «.»!";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (true);
    }
}