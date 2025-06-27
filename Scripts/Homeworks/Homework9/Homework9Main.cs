using System.Text;
using IT_Academy_CSharp.SideFiles;

namespace IT_Academy_CSharp.Homeworks.Homework9;

public static class Homework9Main
{
    public static void RunHomework9()
    {
        RunHomework9Task1();
        RunHomework9Task2(); 
        RunHomework9Task3();
    }

    private static void RunHomework9Task1()
    {
        var students = CreateStudentsList(3);

        if (students.Count > 0)
        {
            PrintStudentBase(students);
            PrintReversedScores(students);
            PrintYoungestStudentInfo(students);
        }
        else
        {
            Console.WriteLine("No students found.");
        }

        MyUtilities.PrintSeparationLine('-');
    }

    private static void PrintStudentBase(List<Student> students)
    {
        Console.WriteLine($"There are {students.Count} students in out base:");
        var output = new StringBuilder().AppendJoin("\n", students);

        MyUtilities.PrintGreenColorMessage(output.ToString());
        Console.WriteLine();
    }

    private static List<Student> CreateStudentsList(int studentsCount)
    {
        var students = new List<Student>();
        for (var i = 0; i < studentsCount; i++)
        {
            students.Add(new Student());
        }

        return students;
    }

    private static void PrintReversedScores(List<Student> students)
    {
        var scores = students.OrderByDescending(s => s.AverageScore);
        var output = new StringBuilder().AppendJoin("\n", scores);

        Console.WriteLine("Reversed students scores: ");
        MyUtilities.PrintGreenColorMessage(output.ToString());
    }

    private static void PrintYoungestStudentInfo(List<Student> students)
    {
        var minAge = students.Min(s => s.Age);
        var youngestStudents = students.FindAll(s => s.Age == minAge);

        var message = youngestStudents.Count == 1
            ? "\nThe youngest student is:"
            : $"There are {youngestStudents.Count} students {youngestStudents.First().Age} years old:";
        MyUtilities.PrintGreenColorMessage(message);

        foreach (var student in youngestStudents)
        {
            MyUtilities.PrintGreenColorMessage(student.ToString());
        }
    }

    private static void RunHomework9Task2()
    {
        var products = new Dictionary<string, double>
        {
            ["apple"] = 1.5,
            ["orange"] = 2.8,
            ["kiwi"] = 4.0,
            ["banana"] = 2.2,
            ["pineapple"] = 5.5,
            ["grape"] = 2.4,
            ["mango"] = 3.9,
        };

        if (products.Count > 0)
        {
            var sortedProducts = products
                .OrderBy(p => p.Key).ToDictionary();

            PrintDictionary(sortedProducts);
            FindProductByName(sortedProducts);

            var increment = 1.1;
            ChangeProductsPrice(sortedProducts, increment);
            PrintDictionary(sortedProducts);
        }
        else
        {
            var errorMessage = "There are no products with that name.";
            MyUtilities.PrintRedColorMessage(errorMessage);
        }

        MyUtilities.PrintSeparationLine('-');
    }

    private static void ChangeProductsPrice(Dictionary<string, double> products, double increment)
    {
        foreach (var key in products.Keys.ToList())
        {
            products[key] *= increment;
        }
    }

    private static void PrintDictionary(Dictionary<string, double> products)
    {
        Console.WriteLine("Product list with prices:");
        foreach (var product in products)
        {
            MyUtilities.PrintGreenColorMessage($"{product.Key}: {product.Value:F2} $");
        }

        Console.WriteLine();
    }

    private static void FindProductByName(Dictionary<string, double> products)
    {
        Console.Write("Enter product name: ");
        var input = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

        var message = products.TryGetValue(input, out var price)
            ? $"The price of the \"{input}\" is: {price:F2} $"
            : $"The product \"{input}\" is not found.";

        MyUtilities.PrintGreenColorMessage(message);
        Console.WriteLine();
    }

    private static void RunHomework9Task3()
    {
        if (InvalidUserInput(out var input)) return;

        var separators = MyUtilities.DefaultSeparatorChars;
        var separatedWords = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var wordsBase = new Dictionary<string, int>();
        foreach (var word in separatedWords)
        {
            if (wordsBase.TryGetValue(word, out _))
            {
                wordsBase[word]++;
            }
            else
            {
                wordsBase[word] = 1;
            }
        }

        Console.WriteLine("\nUnique words and their counts:");
        foreach (var word in wordsBase)
        {
            Console.WriteLine($"{word.Key}: {word.Value}");
        }

        MyUtilities.PrintSeparationLine('-');
    }

    private static bool InvalidUserInput(out string input)
    {
        Console.WriteLine("Enter any text to count unique words: ");
        input = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(input)) return false;
        
        MyUtilities.PrintRedColorMessage("Your input is invalid!");
        return true;
    }
}