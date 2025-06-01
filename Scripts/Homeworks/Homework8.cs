using System.Text;

namespace IT_Academy_CSharp;

public static class Homework8
{
    public static void RunHomework8()
    {
        Console.WriteLine("\n\tHOMEWORK #8\n");
        RunHomework8Part1();
        RunHomework8Part2();
        RunHomework8Part3();
        MyUtilities.PrintSeparationLine('-');
    }

    /*
   Задание 1:
   Напишите программу, которая принимает строку и проверяет, является ли она палиндромом.
   Палиндром — это слово или фраза, которая читается одинаково с обеих сторон (например, "level", "madam").
   Учесть что введённая строка может быть с пробелами и буквами в разном регистре
 */
    private static void RunHomework8Part1()
    {
        Console.WriteLine("\n\tTask 1:");

        var promptMessage = "Enter text to check for palindrome: ";
        if (GetUserInput(promptMessage, out var input)) return;

        input = new string(input.ToLowerInvariant().Where(char.IsLetter).ToArray());

        var subStrLength = input.Length / 2;
        var firstSubString = input[..subStrLength];

        var secondSubString = input.Length % 2 == 0
            ? input[subStrLength..]
            : input[(subStrLength + 1)..];
        secondSubString = new string(secondSubString.Reverse().ToArray());

        var isEqual = string.Equals(firstSubString, secondSubString);
        var resultMessage = isEqual
            ? "The input is a palindrome."
            : "The input is not a palindrome.";
        Console.WriteLine(resultMessage);
    }

    private static bool GetUserInput(string promptMessage, out string input)
    {
        Console.Write(promptMessage);
        input = Console.ReadLine() ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(input)) return false;

        var errorMessage = "The entered text is empty.";
        Console.WriteLine(errorMessage);
        return true;
    }

/*
   Задание 2:
   Напишите программу, которая удаляет все пробелы из строки с помощью класса StringBuilder.
   Например, дано: "Hello World", вы должны вернуть "HelloWorld".
 */
    private static void RunHomework8Part2()
    {
        Console.WriteLine("\n\tTask 2:");

        var promptMessage = "Enter any text: ";
        if (GetUserInput(promptMessage, out var input)) return;

        var strBuilder = new StringBuilder(input);
        strBuilder.Replace(" ", "");
        Console.WriteLine(strBuilder);
    }

/*
   Задание 3:
   Напишите программу, которая преобразует строку в:
   Все строчные буквы.
   Все заглавные буквы.
   Первую букву каждого слова в заглавную.

   Пример ввода и вывода:
   Введите строку: hello world

   Результат:
   Все строчные: hello world
   Все заглавные: HELLO WORLD
   Первая буква каждого слова c заглавной: Hello World
 */
    private static void RunHomework8Part3()
    {
        Console.WriteLine("\n\tTask 3:");

        var promptMessage = "Enter any text: ";
        if (GetUserInput(promptMessage, out var input)) return;

        Console.WriteLine($"Lower case: {input.ToLowerInvariant()}");
        Console.WriteLine($"Upper case: {input.ToUpperInvariant()}");

        var strBuilder = new StringBuilder();
        var result = string.Empty;

        var separateWords = input.Split(" ");
        foreach (var word in separateWords)
        {
            var firstChar = word.First().ToString().ToUpperInvariant();
            result = word.Length > 1
                ? strBuilder.Append($"{firstChar + word[1..]} ").ToString()
                : strBuilder.Append($"{firstChar} ").ToString();
        }

        Console.WriteLine($"Title case: {result}");
    }
}