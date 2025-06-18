using IT_Academy_CSharp.MyExceptions;

namespace IT_Academy_CSharp.Homeworks.Homework11;

public abstract class BaseCharacter
{
    private string? _name;
    private int _health;

    public string? Name
    {
        get => _name;
        set => _name = ValidateCharacterName(value);
    }

    public int Health
    {
        get => _health;
        set => _health = ValidateCharacterHealth(value);
    }

    private protected BaseCharacter(string? name, int health)
    {
        Name = name;
        Health = health;
    }

    private string ValidateCharacterName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new MyNameValueException("Name cannot be null or whitespace.");
        }

        return name;
    }

    private int ValidateCharacterHealth(int newHealthValue)
    {
        if (newHealthValue < 0)
        {
            throw new MyHealthValueException("Health cannot be negative.");
        }

        return newHealthValue;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Health: {Health}";
    }
}