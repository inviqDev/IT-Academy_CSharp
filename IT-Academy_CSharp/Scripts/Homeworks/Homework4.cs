namespace IT_Academy_CSharp;

public static partial class Homework4
{
    private static readonly Random Random = new();

    public static void RunHomework4()
    {
        Console.WriteLine("\tHomework 4");

        RunHomework4Part1();
        RunHomework4Part2();
        RunHomework4Part3();
        RunHomework4Part4();

        MyUtilities.SayByeBye(3);
    }
}

/*
 * Homework #4 Task 1:
 * Создать массив элементов произвольного типа.
 * С помощью всех циклов перебрать все элементы этого массива и вывести их на консоль.
 */
public static partial class Homework4
{
    private static void RunHomework4Part1()
    {
        var arraySize = 8; // <= Implement Console.ReadLine() for flexibility?
        var array = InstantiateNewArray(arraySize);

        if (array != null)
        {
            FillArrayWithRandomInt(array);
            PrintTask1FinalResult(array);
        }
        else
        {
            var errorDescription = "Instantiated array is null.";
            MyUtilities.PrintRedColorMessage(errorDescription);
        }
        
        MyUtilities.PrintSeparationLine('-');
    }

    private static void PrintTask1FinalResult(int[] array)
    {
        PrintArrayUsingForLoop(array);
        PrintArrayUsingWhileLoop(array);
        PrintArrayUsingDoWhileLoop(array);
        PrintArrayUsingForeachLoop(array);
    }

    private static int[]? InstantiateNewArray(int arraySize)
    {
        var minArraySize = 1;
        var array = arraySize >= minArraySize ? new int[arraySize] : null;
        
        return array;
    }

    private static void FillArrayWithRandomInt(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = Random.Next(int.MinValue, int.MaxValue);
        }
    }

    private static void PrintArrayUsingForLoop(int[] array)
    {
        MyUtilities.PrintGreenColorMessage("\nPrint with \"For loop\"\n");
        for (var i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Index {i} : {array[i]}");
        }
    }

    private static void PrintArrayUsingWhileLoop(int[] array)
    {
        MyUtilities.PrintGreenColorMessage("\nPrint with \"While loop\"\n");

        var index = 0;
        while (index < array.Length)
        {
            Console.WriteLine($"Index {index} : {array[index++]}");
        }
    }

    private static void PrintArrayUsingDoWhileLoop(int[] array)
    {
        MyUtilities.PrintGreenColorMessage("\nPrint with \"Do-While loop\"\n");

        var index = 0;
        do
        {
            Console.WriteLine($"Index {index} : {array[index++]}");
        } while (index < array.Length);
    }

    private static void PrintArrayUsingForeachLoop(int[] array)
    {
        MyUtilities.PrintGreenColorMessage("\nPrint with \"Foreach loop\"\n");

        var index = 0;
        foreach (var item in array)
        {
            Console.WriteLine($"Index {index} : {item}");
            index++;
        }
    }
}

/*
 * Homework #4 Task 2:
 * С помощью цикла со счетчиком вывести на экран в одну строку все двузначные числа, кратные 5.
 */
public static partial class Homework4
{
    private static void RunHomework4Part2()
    {
        var minTwoDigitNumber = -99;
        var maxTwoDigitNumber = 99;
        var divider = 5;
        var taskResult = string.Empty;

        for (var i = minTwoDigitNumber; i <= maxTwoDigitNumber; i++)
        {
            if (i % divider == 0)
            {
                taskResult += $"{i.ToString()} ";
            }
        }

        Console.Write($"Two‑digit numbers divisible by {divider.ToString()}:\n{taskResult}\n");
        MyUtilities.PrintSeparationLine('-');
    }
}

/*
 * Homework #4 Task 3:
 * С помощью цикла с постусловием вывести на экран в столбик последовательность чисел: -20, -40, ...,-100.
 */
public static partial class Homework4
{
    private static void RunHomework4Part3(int startValue = -20)
    {
        var result = string.Empty;
        do
        {
            result += $"{startValue.ToString()}\n";
            startValue -= 20;
        } while (startValue >= -100);

        Console.Write(result);
        MyUtilities.PrintSeparationLine('-');
    }
}

/*
 * Homework #4 Task 4:
 * Ввести с клавиатуры символ. Определить, необходимо ли нам переместить фигуру
 * вверх, вниз, вправо, влево в зависимости от введенного символа (W, S, A, D).
 * Вывести результат решения на экран (сообщение: фигура перемещена вверх/вниз/и т.д.).
 * В случае отсутствия необходимости перемещения вывести соответствующее сообщение.
 */
public static partial class Homework4
{
    private static void RunHomework4Part4()
    {
        do
        {
            PrintTask4PromptMessage();
            var pressedKey = Console.ReadKey(true).Key;
            if (pressedKey == ConsoleKey.Escape)
            {
                PrintEndGameMessage();
                break;
            }

            PlaySingleGameTurn(pressedKey);
        } while (true);
    }

    private static void PrintTask4PromptMessage()
    {
        var promptMessage = "Press W, A, S, D to move your figure.\n" +
                            "Or press \"Esc\" button to leave the game!";
        Console.WriteLine(promptMessage);
    }

    private static void PlaySingleGameTurn(ConsoleKey input)
    {
        var directionMessage = input switch
        {
            ConsoleKey.W => "Your figure moves up",
            ConsoleKey.S => "Your figure moves down",
            ConsoleKey.A => "Your figure moves left",
            ConsoleKey.D => "Your figure moves right",
            _ => string.Empty
        };
        
        PrintTurnResult(directionMessage);
    }

    private static void PrintTurnResult(string turnResult)
    {
        if (turnResult != string.Empty)
        {
            MyUtilities.PrintGreenColorMessage($"\n{turnResult}\n");
        }
        else
        {
            var errorDescription = "Unacceptable keyboard input!";
            MyUtilities.PrintRedColorMessage($"\n{errorDescription}\n");
        }
    }

    private static void PrintEndGameMessage()
    {
        Console.Clear();

        var endGameMessage = "\n\tGame over!\n";
        MyUtilities.PrintRedColorMessage($"\n{endGameMessage}\n");
        
        MyUtilities.PlaySadMelody();
        MyUtilities.SayByeBye(2);
    }
}