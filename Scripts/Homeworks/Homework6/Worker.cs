namespace IT_Academy_CSharp.Homework6;

public class Worker : EmployeeBase
{
    private int _experience;

    public int Experience
    {
        get => _experience;
        private set => SetWorkerExperience(value);
    }

    public Shifts Shift { get; private set; }

    public Worker()
    {
        Position = Positions.Worker;
        Experience = GetWorkerExperience();
        Shift = GetWorkerShift();
    }

    public Worker(string? name, int experience, Shifts shift) : base(name)
    {
        Position = Positions.Worker;
        Experience = experience;
        Shift = shift;
    }

    public override void GetDetails()
    {
        var baseInfo = GetEmployeeBaseInfo();
        var uniqueInfo = GetWorkerUniqueInfo();
        MyUtilities.PrintGreenColorMessage($"{baseInfo} | {uniqueInfo}");
    }

    private static int GetWorkerExperience()
    {
        do
        {
            Console.WriteLine("Please, enter a new worker experience (years): ");
            if (int.TryParse(Console.ReadLine()?.Trim(), out var experience) && experience >= 0)
            {
                var workerExperienceMessage = $"\nWorker's experience is set to {experience} years\n";
                MyUtilities.PrintGreenColorMessage(workerExperienceMessage);
                return experience;
            }

            var errorMessage = "\nInvalid input! Please enter a whole number >= 0\n";
            MyUtilities.PrintRedColorMessage(errorMessage);
        } while (true);
    }

    public void SetWorkerExperience(int experience)
    {
        _experience = experience >= 0 ? experience : 0;
    }

    public void IncreaseWorkerExperience()
    {
        _experience++;
    }

    private static Shifts GetWorkerShift()
    {
        var menuOptionsAmount = 3;
        var validButtons = MyUtilities.GetAllowedNumericKeys(menuOptionsAmount);

        do
        {
            Console.WriteLine(ConsoleMessages.WorkerShiftSelectionPrompt);
            var input = Console.ReadKey(true).Key;
            if (Array.Exists(validButtons, _ => _ == input))
            {
                var shiftType = input switch
                {
                    ConsoleKey.D1 or ConsoleKey.NumPad1 => Shifts.Day,
                    ConsoleKey.D2 or ConsoleKey.NumPad2 => Shifts.Evening,
                    ConsoleKey.D3 or ConsoleKey.NumPad3 => Shifts.Night,
                };

                var workerShiftTypeMessage = $"\nWorker's shift is set to {shiftType}\n";
                MyUtilities.PrintGreenColorMessage(workerShiftTypeMessage);
                return shiftType;
            }

            var errorMessage = ConsoleMessages.WorkerShiftSelectionInvalidInputMessage;
            MyUtilities.PrintRedColorMessage(errorMessage);
        } while (true);
    }

    public void ChangeWorkerShift(Shifts shift)
    {
        Shift = shift;
    }

    private string GetWorkerUniqueInfo()
    {
        return $"Experience: {Experience} years | Current shift: {Shift}\n";
    }
}