namespace IT_Academy_CSharp.Homework9;

public class Student
{
    private static readonly Random Random = new();
    public string Name { get; set; }
    public int Age { get; set; }
    public double AverageScore { get; set; }

    public Student()
    {
        Name = MyUtilities.GetRandomName(Random.Next(0, MyUtilities.NamesBase.Length));
        Age = Random.Next(17, 34);
        AverageScore = SetRandomAverageScore();
    }

    private double SetRandomAverageScore()
    {
        double randomDouble;
        do
        {
            randomDouble = Random.NextDouble();
        } while (randomDouble < 0.5); // loop again to avoid "nonsense values"
        
        return randomDouble * 10;
    }

    public override string ToString()
    {
        return $"{Name}: age is {Age}, average score is {Math.Round(AverageScore, 3):F2}";
    }
}