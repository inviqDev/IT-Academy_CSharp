namespace IT_Academy_CSharp.Homeworks.Homework12;

public class User
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }

    public User()
    {
    }

    public User(string? name, int age, string? email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Email: {Email}";
    }
}