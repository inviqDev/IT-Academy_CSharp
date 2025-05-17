namespace IT_Academy_CSharp;

public static class Homework3
{
    private const string PromptMessageTask1 = "Enter a desired age: ";
    private const int MinAgeValue = 0;

    private const string PromptMessageTask2 = "Please, select a boolean value:\n" +
                                              "Keyboard \"Number 1\" button => True\n" +
                                              "Keyboard \"Number 2\" button => False";

    public static void RunHomework3()
    {
        RunHomework3Task1();
        RunHomework3Task2();

        Console.WriteLine("\tBye, Bye!");
    }

    #region Homework3Part1

    private static void RunHomework3Task1()
    {
        Console.WriteLine("\tHomework #3 Task #1\n");

        do
        {
            Console.Write(PromptMessageTask1);

            var isValidInput = int.TryParse(Console.ReadLine()?.Trim(), out var userAge);
            if (isValidInput && userAge >= MinAgeValue)
            {
                PrintSuccessResultTask1(userAge);
                break;
            }

            PrintErrorTask1(isValidInput);
        } while (true);
    }

    private static void PrintSuccessResultTask1(int userAge)
    {
        var userAgeParity = userAge % 2 == 0 ? "even" : "odd";
        var userAgeGroup = userAge switch
        {
            <= 2 => Enums.AgeGroup.Infant,
            <= 12 => Enums.AgeGroup.Child,
            <= 17 => Enums.AgeGroup.Teenager,
            <= 59 => Enums.AgeGroup.Adult,
            >= 60 => Enums.AgeGroup.Senior
        };

        var summaryResultMessage = $"The age ({userAge}) you entered is {userAgeParity}.\n" +
                                   $"This age falls into the \"{userAgeGroup}\" category.";
        MyUtilities.PrintGreenColorMessage($"\n{summaryResultMessage}");
        MyUtilities.PrintSeparationLine('-');
    }

    private static void PrintErrorTask1(bool isValidInput)
    {
        var errorDescription = !isValidInput
            ? "Invalid input! Please enter a whole number >= 0."
            : $"Age cannot be less than {MinAgeValue}. Please try again.";
        MyUtilities.PrintRedColorMessage($"\n{errorDescription}\n");
    }

    #endregion

    #region Homework3Part2

    private static void RunHomework3Task2()
    {
        Console.WriteLine("\tHomework #3 Task #2\n");

        var firstBool = GetBooleanValue();
        var secondBool = GetBooleanValue();
        PrintSuccessResultTask2(firstBool, secondBool);
    }

    private static bool GetBooleanValue()
    {
        do
        {
            Console.WriteLine(PromptMessageTask2);

            var userInput = Console.ReadKey(true).Key;
            var validInput = userInput switch
            {
                ConsoleKey.D1 or ConsoleKey.D2 => true,
                ConsoleKey.NumPad1 or ConsoleKey.NumPad2 => true,
                _ => false
            };
            
            if (validInput)
            {
                var inputResult = userInput == ConsoleKey.D1;
                MyUtilities.PrintGreenColorMessage($"\nThe chosen boolean is {inputResult}.\n");

                return inputResult;
            }

            PrintErrorTask2();
        } while (true);
    }

    private static void PrintSuccessResultTask2(bool firstBool, bool secondBool)
    {
        var tableTitle = CreateTask2ResultTableTitle();
        var resultsRaw = CreateTask2ResultTableRaw(firstBool, secondBool);
        MyUtilities.PrintGreenColorMessage($"{tableTitle}\n{resultsRaw}");

        MyUtilities.PrintSeparationLine('-');
    }

    private static string CreateTask2ResultTableTitle(int columnWidth = 10)
    {
        var columnTitles = new List<string>
        {
            "  p",
            "  q",
            "p && q",
            "p || q",
            "p ^ q",
            " !p"
        };

        var tableTitle = string.Empty;
        foreach (var title in columnTitles)
        {
            tableTitle += title.PadRight(columnWidth);
        }
        
        return tableTitle;
    }

    private static string CreateTask2ResultTableRaw(bool firstBool, bool secondBool, int columnWidth = 10)
    {
        var comparingResults = new List<bool>
        {
            firstBool,
            secondBool,
            firstBool && secondBool,
            firstBool || secondBool,
            firstBool ^ secondBool,
            !firstBool
        };
        
        var comparingResultsTableRaw = string.Empty;
        foreach (var result in comparingResults)
        {
            comparingResultsTableRaw += result.ToString().PadRight(columnWidth);
        }

        return comparingResultsTableRaw;
    }


    private static void PrintErrorTask2()
    {
        var errorDescription = "Invalid input! Please choose a boolean again:\n" +
                               "Keyboard \"Number 1\" button => True\n" +
                               "Keyboard \"Number 2\" button => False";
        MyUtilities.PrintRedColorMessage($"\n{errorDescription}\n");
    }

    #endregion
}