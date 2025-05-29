using System.Text;

namespace IT_Academy_CSharp;

/*
 * Задание 1:
   - Объявить и проинициализировать массив int[] на 6 элементов.
   - Ввести значения элементов массива из консоли.
   - Вывести введенные отсортированные по убыванию элементы массива на экран.

   Задание 2:
   - Создать двумерный массив 3х3. Значения элементов массива инициализировать при объявлении массива.
   - Вывести на экран значения максимального элемента каждого ряда.
 */

public static class Homework7
{
    private static readonly Random Random = new();
    private static int _rows = 3; // 24
    private static int _columns = 3; // 28
    private static int _minRandomValue = 10;
    private static int _maxRandomValue = 100;

    public static void RunHomework7()
    {
        Console.WriteLine("\n\tHOMEWORK #7:\n");
        RunHomework7Part1();
        RunHomework7Part2();
        MyUtilities.PrintSeparationLine('-');
    }

    private static void RunHomework7Part2()
    {
        var array = CreateTwoDimensionalArray(_rows, _columns, _minRandomValue, _maxRandomValue);

        var finalResult = new StringBuilder();
        var maxValues = new List<int>();
        for (var currentRow = 0; currentRow < array.GetLength(0); currentRow++)
        {
            var maxValue = GetRowMaxValue(array, currentRow);
            maxValues.Add(maxValue);
            finalResult.Append($"The highest value in row {currentRow + 1} is {maxValue}\n");
        }

        PrintTwoDimensionsArray(array, maxValues);
        MyUtilities.PrintSeparationLine('-');
        MyUtilities.PrintGreenColorMessage(finalResult.ToString());
    }

    private static void PrintTwoDimensionsArray(int[,] array, List<int> maxValues)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == maxValues[i])
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{array[i, j].ToString()} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{array[i, j]} ");
                }
            }

            Console.WriteLine();
        }
    }

    private static int[,] CreateTwoDimensionalArray(int rows, int columns, int minRandom, int maxRandom)
    {
        var array = new int[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                array[i, j] = Random.Next(minRandom, maxRandom);
            }
        }

        return array;
    }

    private static int GetRowMaxValue(int[,] array, int currentRow)
    {
        var maxValue = array[currentRow, 0];
        for (var i = 0; i < array.GetLength(1); i++)
        {
            if (array[currentRow, i] > maxValue)
            {
                maxValue = array[currentRow, i];
            }
        }

        return maxValue;
    }

    private static void RunHomework7Part1()
    {
        CreateArray(out var array);
        Array.Sort(array, (x, y) => y.CompareTo(x));

        var description = "\nSorted array in reverse order: ";
        var sortedArray = new StringBuilder();
        sortedArray.AppendJoin(" ", array);

        MyUtilities.PrintGreenColorMessage($"{description}: {sortedArray}");

        MyUtilities.PrintSeparationLine('-');
    }

    private static void CreateArray(out int[] array, int arraySize = 6)
    {
        var promptMessage = "Please enter 6 whole numbers, separated by spaces.\n" +
                            "Or enter \"Exit!\" to close this annoying program :)\n";

        do
        {
            Console.Write(promptMessage);
            if (!GetUserInput(arraySize, out var input)) continue;
            if (FillArrayWithValidValues(out array, arraySize, input!)) return;
        } while (true);
    }

    private static bool FillArrayWithValidValues(out int[] array, int arraySize, string[] input)
    {
        array = new int[arraySize];
        for (var i = 0; i < arraySize; i++)
        {
            if (int.TryParse(input[i], out var value))
            {
                array[i] = value;
                if (i == arraySize - 1) return true;
            }
            else
            {
                var detailedError = $"\nYour input \"{input[i]}\" is not a whole number.\n" +
                                    $"Please try again.\n";
                MyUtilities.PrintRedColorMessage(detailedError);
            }
        }

        return false;
    }

    private static bool GetUserInput(int arraySize, out string[]? input)
    {
        input = Console.ReadLine()?.Trim().Split(" ") ?? [];
        foreach (var str in input)
        {
            if (str.Equals("exit!", StringComparison.CurrentCultureIgnoreCase))
            {
                MyUtilities.ExitProgram();
            }
        }

        var inputIsValid = ValidateInputTask1(arraySize, input);
        return inputIsValid;
    }

    private static bool ValidateInputTask1(int arraySize, string[] input)
    {
        if (input.Length != arraySize)
        {
            var detailedError = $"\n\"You have entered {input.Length} values!.\n" +
                                $"Please enter {arraySize} values. Try again..\n";
            MyUtilities.PrintRedColorMessage(detailedError);
            return false;
        }

        foreach (var str in input)
        {
            if (int.TryParse(str, out var _)) continue;

            var detailedError = $"\n\"{str}\" is not a whole number.\nPlease try again.\n";
            MyUtilities.PrintRedColorMessage(detailedError);
            return false;
        }

        return true;
    }
}