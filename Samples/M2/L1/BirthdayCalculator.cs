using System.Diagnostics.CodeAnalysis;

namespace L1;

public class BirthdayCalculator
{
    public const string Song = "Happy Birthday to You!";
    public readonly string Name = "Mr Incognito";

    public DateTime DateOfBirth { get; init; }
    public required string TimeZone { get; init; }

    [SetsRequiredMembers]
    public BirthdayCalculator(string name, DateTime dateOfBirth, string timeZone)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        TimeZone = timeZone;
    }

    public void Sing()
    {
        var today = DateTime.Today;

        if (today.Day == DateOfBirth.Day && today.Month == DateOfBirth.Month)
        {
            var age = today.Year - DateOfBirth.Year;
            Console.WriteLine($"{Song}, {Name}! You are {age} years old ;)");
        }
        else
        {
            var next = DateOfBirth.AddYears(today.Year - DateOfBirth.Year);
            if (next < today) next = next.AddYears(1);
            int numDays = (next - today).Days;

            Console.WriteLine($"It is not your birthday yet, {Name}, to your birthday {numDays} days left.");
        }
    }
}
