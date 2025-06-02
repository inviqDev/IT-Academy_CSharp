namespace IT_Academy_CSharp.Homework9;

public static class Homework9Main
{
    public static void RunHomework9()
    {
        RunHomework9Task1();
        // RunHomework9Task2();
        // RunHomework9Task3();
    }

    private static void RunHomework9Task1()
    {
        var students = CreateStudentsList(97);

        if (students.Count > 0)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            PrintReversedScores(students);
            PrintYoungestStudentInfo(students);
        }
        else
        {
            Console.WriteLine("No students found.");
        }
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

        Console.WriteLine("Reversed students scores: ");
        foreach (var score in scores)
        {
            Console.Write($"{score.AverageScore:F2} ");
        }

        Console.WriteLine();
    }

    private static void PrintYoungestStudentInfo(List<Student> students)
    {
        var youngestStudents = students.FindAll(s => s.Age == students.Min(stud => stud.Age));

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
            ["banana"] = 2.2,
            ["orange"] = 2.8,
            ["kiwi"] = 4.0,
            ["pineapple"] = 5.5,
            ["mango"] = 3.9,
            ["grape"] = 2.4
        };

        PrintDictionary(products);
        FindProductByPrice(products);

        var increnent = 1.1;
        ChangeAllProductsPrice(products, increnent);
        PrintDictionary(products);
    }

    private static void ChangeAllProductsPrice(Dictionary<string, double> products, double increment)
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

    private static void FindProductByPrice(Dictionary<string, double> products)
    {
        Console.Write("Enter product name: ");
        var input = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

        var message = products.TryGetValue(input, out var price)
            ? $"The price of \"{input}\" is: {price:F2} $"
            : $"Product \"{input}\" not found.";

        MyUtilities.PrintGreenColorMessage(message);
        Console.WriteLine();
    }


    private static void RunHomework9Task3()
    {
        if (GetUserInput(out var input)) return;

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
    }

    private static bool GetUserInput(out string input)
    {
        Console.WriteLine("Enter any text to count unique words: ");
        input = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

        if (input is not (null or "")) return false;

        MyUtilities.PrintRedColorMessage("Your input is invalid!");
        return true;
    }
}