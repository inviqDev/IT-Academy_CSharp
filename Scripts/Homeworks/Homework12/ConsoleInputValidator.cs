using System.Text;

namespace IT_Academy_CSharp.Homeworks.Homework12;

public static class ConsoleInputValidator
{
    public static string GetValidatedUserNameFromConsole()
    {
        do
        {
            Console.Write("Please enter a user name: ");
            var input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            
            if (MyUtilities.CredentialValidation.IsMatch(input))
            {
                var splittedNames = input.Split(' ');
                
                return splittedNames.Length == 1 
                    ? CapitalizeValidatedUserName(input) 
                    : CapitalizeValidatedUserName(splittedNames);
            }

            var notMatchedRegexInputError = "\nInvalid user name!\nPlease try again!\n";
            MyUtilities.PrintRedColorMessage(notMatchedRegexInputError);
        } while (true);
    }
    
    private static string CapitalizeValidatedUserName(string[] splittedNames)
    {
        var builder = new StringBuilder();
        
        foreach (var name in splittedNames)
        {
            builder.Append($"{CapitalizeValidatedUserName(name)} ");
        }

        MyUtilities.PrintGreenColorMessage($"\nA user name is set to: {builder}\n");
        return builder.ToString().Trim();
    }
    
    private static string CapitalizeValidatedUserName(string userName)
    {
        var builder = new StringBuilder();

        var inputInCharArray = userName.ToCharArray();
        inputInCharArray[0] = char.ToUpper(inputInCharArray[0]);

        return builder.AppendJoin("", inputInCharArray).ToString();
    }
    
    public static int GetValidatedUserAgeFromConsole()
    {
        do
        {
            Console.Write("Please enter a user age: ");
            if (int.TryParse(Console.ReadLine()?.Trim(), out var intValue))
            {
                if (intValue >= 0)
                {
                    MyUtilities.PrintGreenColorMessage($"\nA user age is set to: {intValue} years\n");
                    return intValue;
                }

                var negativeAgeError = "\nAge cannot be negative. Please try again!\n";
                MyUtilities.PrintRedColorMessage(negativeAgeError);
                continue;
            }

            var notParsedInputError = "\nInvalid user age input!\nPlease enter a whole number\n";
            MyUtilities.PrintRedColorMessage(notParsedInputError);
        } while (true);
    }

    public static string GetValidatedUserEmailFromConsole()
    {
        do
        {
            Console.WriteLine("Please enter a user email: ");
            var input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            if (MyUtilities.EmailValidation.IsMatch(input))
            {
                MyUtilities.PrintGreenColorMessage($"\nA user email is set to: {input}\n");
                return input;
            }

            var notMatchedRegexInputError = "\nInvalid user email!\nPlease try again!\n";
            MyUtilities.PrintRedColorMessage(notMatchedRegexInputError);
        } while (true);
    }
}