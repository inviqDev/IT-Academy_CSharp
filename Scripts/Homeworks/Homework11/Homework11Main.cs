using IT_Academy_CSharp.MyExceptions;
using IT_Academy_CSharp.SideFiles;

namespace IT_Academy_CSharp.Homeworks.Homework11;

public static class Homework11Main
{
    public static void RunHomework11()
    {
        var geralt = new GeraltOfRivia("Geralt", 100);
        Console.WriteLine($"Valid data:\n{geralt}");

        MyUtilities.PrintSeparationLine('-');
        Console.WriteLine("Trying to change a character's name to \"string.empty\" value.\n");
        ChangeCharacterName(geralt, string.Empty);

        MyUtilities.PrintSeparationLine('-');
        Console.WriteLine("Trying to change a character's health to negative value.\n");
        ChangeCharacterHealth(geralt, -20);
    }

    private static void ChangeCharacterName(BaseCharacter character, string name)
    {
        try
        {
            character.Name = name;
        }
        catch (MyNameValueException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void ChangeCharacterHealth(BaseCharacter character, int healthValue)
    {
        try
        {
            character.Health = healthValue;
        }
        catch (MyBaseException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}