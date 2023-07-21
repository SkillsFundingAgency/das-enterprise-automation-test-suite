using System;

namespace SFA.DAS.FrameworkHelpers;

public class RandomPersonNameHelper
{
    public readonly string FirstName, LastName;

    public RandomPersonNameHelper()
    {
        FirstName = GenerateRandomFirstName();
        LastName = GenerateRandomLastName();
    }

    private static string GenerateRandomFirstName() => GenerateRandom(new string[] { "Oliver", "George", "Noah", "Arthur", "Harry", "Jack", "Charlie", "Henry",
            "Michael", "Ethan", "Thomas", "Freddie", "William", "James", "Edward", "Scarlett", "Daisy", "Phoebe",
            "Isabella", "Evelyn", "Lily", "Mia", "Emily", "Charlotte", "Rosie", "Amelia", "Olivia", "Eva", "Sophia", "Grace"});

    private static string GenerateRandomLastName() => GenerateRandom(new string[] { "Cox", "Jones", "Taylor", "Williams", "Brown", "White", "Harris", "Martin",
            "Davies", "Wilson", "Cooper", "Evans", "King", "Baker", "Green", "Wright", "Clark", "Webb",
            "Robinson", "Hall", "Young", "Turner", "Hill", "Collins", "Allen", "Moore", "Knight", "Walker", "Wood", "Bennett"});

    private static string GenerateRandom(string[] names) => names[new Random().Next(names.Length)];
}
