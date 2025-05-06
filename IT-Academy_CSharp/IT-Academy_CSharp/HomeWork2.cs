namespace IT_Academy_CSharp;

public static class HomeWork2
{
    public static void RunHomeWork2()
    {
        RunHomeWork2Part1();
        MyUtilities.PrintSeparationLine('-');
        RunHomeWork2Part2();
        MyUtilities.PrintSeparationLine('-');
        Console.WriteLine("Bye, Bye!");
    }

    private static void RunHomeWork2Part1()
    {
        Console.WriteLine("\tЗадание №2.1\n");

        var promptMessage = "Введите Ваше имя: ";
        Console.Write(promptMessage);
        var userName = Console.ReadLine()?.Trim();

        promptMessage = "Введите Ваш возраст: ";
        var userAge = GetValidUserAge(promptMessage);

        promptMessage = "Введите Ваш рост (в метрах): ";
        var userHeight = GetValidUserHeight(promptMessage);

        var taskResultOutputMessage = $"Привет, {userName}!\n" +
                                      $"\tВаш возраст: {userAge} лет.\n" +
                                      $"\t\tВаш рост: {userHeight:F2} м.";
        MyUtilities.PrintValidMessage(taskResultOutputMessage);
    }

    private static double GetValidUserHeight(string? promptMessage)
    {
        double userHeight;
        do
        {
            Console.Write(promptMessage);

            var validInput = double.TryParse(Console.ReadLine()?.Trim().Replace(',', '.'), out userHeight);
            if (validInput && userHeight > 0)
            {
                continue;
            }

            var errorDescription = !validInput
                ? "Неверный формат ввода.\nПожалуйста, введите целое или дробное число (например, 1.64 или 1,64)"
                : "Рост не может быть отрицательным.\nПожалуйста, введите число > 0.";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (userHeight <= 0);

        return userHeight;
    }

    private static int GetValidUserAge(string? promptMessage)
    {
        int userAge;
        do
        {
            Console.Write(promptMessage);
            var validInput = int.TryParse(Console.ReadLine()?.Trim().Replace('.', '.'), out userAge);
            if (validInput && userAge > 0)
            {
                continue;
            }

            var errorDescription = !validInput
                ? "Неверный формат ввода.\nПожалуйста, введите целое число."
                : "Возраст не может быть отрицательным.\nПожалуйста, введите число > 0.";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (userAge <= 0);

        return userAge;
    }

    private static void RunHomeWork2Part2()
    {
        Console.WriteLine("\tЗадание №2.2\n");

        var promptMessage = "Введите первое число: ";
        var firstValue = GetValidValue("Введите первое число: ");

        promptMessage = "Введите второе число: ";
        var secondValue = GetValidValue(promptMessage);

        Console.ForegroundColor = ConsoleColor.Green;
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

        Console.ResetColor();
    }

    private static double GetValidValue(string promptMessage)
    {
        double validValue;
        var invalidUserInput = true;
        do
        {
            Console.Write(promptMessage);
            if (double.TryParse(Console.ReadLine()?.Trim().Replace(',', '.'), out validValue))
            {
                invalidUserInput = false;
                continue;
            }

            var errorDescription = "Неверный формат ввода! Пожалуйста, введите целое или дробное число.\n" +
                                   "Разделитель для дробного числа: «,» или «.»!";
            MyUtilities.PrintErrorMessage(errorDescription);
        } while (invalidUserInput);

        return validValue;
    }
}