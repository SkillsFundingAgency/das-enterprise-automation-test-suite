namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public record AANTestData
{
    public string LarsCode;
    public string StandardName;
    public string Venue;
}

public class AANDataHelpers
{
    public const string LocationName = "Test Demo Automation Venue";
    public string VenueName { get; init; } = LocationName;
    public string NewVenueName { get; init; } = "New Venue Test Demo Automation Venue";
    public string Standard_ActuaryLevel7 { get; init; } = "Actuary (Level 7)";
    public string PostCode { get; init; } = "Tw14 9py";
    public string Website { get; init; } = "www.company.co.uk";
    public string JobTitle { get; init; } = "SoftwareTESTER";
    public string NewJobTitle { get; init; } = "AutomationSoftwareTESTER";
    public string UpdatedWebsite { get; init; } = "www.123company.co.uk";
    public string ContactWebsite { get; init; } = "www.companycontact.co.uk";
    public string AddressLine1 { get; init; } = "Automation Address line one";
    public string AddressLine2 { get; init; } = "Automation Address line two";
    public string County { get; init; } = "Automation Address County";
    public string Town { get; init; } = "Automation Address Town";
    public string ContactNumber { get; init; } = RandomDataGenerator.GenerateRandomNumber(12);
    public string UpdateProviderDescriptionText { get; init; } = RandomDataGenerator.GenerateRandomAlphanumericString(20);
}
