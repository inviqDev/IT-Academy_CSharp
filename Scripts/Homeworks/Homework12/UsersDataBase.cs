using System.Text;
using System.Text.Json;

namespace IT_Academy_CSharp.Homeworks.Homework12;

public class UsersDataBase
{
    private readonly string _dataBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private readonly string _usersDataBaseFileName = "users.json";
    private string? _dataBaseFilePath;

    public void AddUserFromConsole()
    {
        var userName = ConsoleInputValidator.GetValidatedUserNameFromConsole();
        var userAge = ConsoleInputValidator.GetValidatedUserAgeFromConsole();
        var userEmail = ConsoleInputValidator.GetValidatedUserEmailFromConsole();

        AddUserToDataBase(userName, userAge, userEmail);
    }

    public void AddUserToDataBase(string? name, int age, string? email)
    {
        var newUser = new User
        {
            Name = name,
            Age = age,
            Email = email
        };

        SaveUser(newUser);
    }

    public void ShowAllUsers()
    {
        var users = LoadAllUsersFromDataBase();

        var usersAmountInfo = $"There are {users.Count} users in the database.\n";
        MyUtilities.PrintGreenColorMessage(usersAmountInfo);

        for (var i = 0; i < users.Count; i++)
        {
            Console.Write($"User #{i + 1} {users[i]}\n");
        }

        Console.WriteLine();
    }

    private void SaveUser(User newUser)
    {
        _dataBaseFilePath ??= Path.Combine(_dataBaseDirectory, _usersDataBaseFileName);
        var newUserData = JsonSerializer.Serialize(newUser);
        File.AppendAllText(_dataBaseFilePath, newUserData + Environment.NewLine);
    }

    private List<User> LoadAllUsersFromDataBase()
    {
        _dataBaseFilePath ??= Path.Combine(_dataBaseDirectory, _usersDataBaseFileName);

        if (!File.Exists(_dataBaseFilePath))
        {
            CreateNewDataBaseFile(_dataBaseFilePath);
        }

        var users = new List<User>();
        var usersFromDataBaseFile = File.ReadAllLines(_dataBaseFilePath);

        foreach (var userData in usersFromDataBaseFile)
        {
            if (string.IsNullOrEmpty(userData)) continue;

            try
            {
                var user = JsonSerializer.Deserialize<User>(userData);
                if (user != null)
                {
                    users.Add(user);
                }
            }
            catch (Exception e)
            {
                var dataBaseIsBrokenError = $"\n\n\nThe User Data Base file is broken!\n" +
                                            $"Possibly it was manually modified on a local disk!\n" +
                                            $"Fix the \"{_dataBaseFilePath}\" file manually!\n\n\n";
                MyUtilities.PrintRedColorMessage(dataBaseIsBrokenError);
                
                Thread.Sleep(5000);
                break;
            }
        }
        
        return users;
    }

    private void CreateNewDataBaseFile(string dataBaseFilePath)
    {
        File.Create(dataBaseFilePath).Dispose();

        // Filling a new DataBase file just for demo purposes => remove the code below in the future 
#region Remove this block of code before release

        var usersDataBase = new UsersDataBase();
        FillUsersDataBase(usersDataBase, 7);
#endregion
    }


    // Helper methods for quickly filling the UsersDataBase with random users for testing or demo purposes
    private static void FillUsersDataBase(UsersDataBase usersDataBase, int usersAmount)
    {
        for (var i = 0; i < usersAmount; i++)
        {
            var defaultUserName = MyUtilities.GetRandomName();
            var defaultUserAge = MyUtilities.Random.Next(0, 150);
            var defaultUserEmail = GetRandomEmail(defaultUserName);

            usersDataBase.AddUserToDataBase(defaultUserName, defaultUserAge, defaultUserEmail);
        }
    }

    private static string GetRandomEmail(string userName)
    {
        var stringBuilder = new StringBuilder();

        var secondPart = MyUtilities.Random.Next(0, 1000).ToString();
        stringBuilder.AppendJoin('_', userName.ToLower(), secondPart);

        var domains = new List<string>
        {
            "@gmail.com",
            "@yahoo.com",
            "@yandex.com",
            "@amazon.com",
        };

        return stringBuilder.Append(domains[MyUtilities.Random.Next(0, domains.Count)]).ToString();
    }
}