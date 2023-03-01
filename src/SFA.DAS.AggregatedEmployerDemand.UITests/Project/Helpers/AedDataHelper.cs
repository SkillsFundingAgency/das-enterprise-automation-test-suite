namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

public record AedDataHelper
{
    public AedDataHelper(string domainName) => Email = $"{GetDateTimeValue()}@{domainName}";
    
    public string Email { get; init; }
    public string RandomWebsiteAddress { get; init; } = "www.TEST" + GetDateTimeValue() + ".com";
    public string TelephoneNumber { get; init; } = $"020{GetRandomNumber(8)}";
    public string Location { get; init; } = RandomDataGenerator.GetRandomElementFromListOfElements(ValidLocations);

    public static string OrganisationName => "Quinton Testing Ltd";

    public static string GetRandomNumber(int length) => RandomDataGenerator.GenerateRandomNumber(length);

    private static string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToUpper();

    private static List<string> ValidLocations => new() { "Crawley, West Sussex", "Bilston, West Midlands", "Coventry, West Midlands", "Canary Wharf, Greater London", "CV1 2WT" };
}
