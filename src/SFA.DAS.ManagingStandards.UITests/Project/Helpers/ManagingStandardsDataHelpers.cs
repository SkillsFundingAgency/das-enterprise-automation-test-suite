namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public record StandardsTestData
{
    public string LarsCode;
    public string StandardName;
    public string Venue;
}

public class ManagingStandardsDataHelpers
{
    public const string LocationName = "Test Demo Automation Venue";
    public string EmailAddress { get; init; } = "ManagingStandardstest.demo@digital.education.gov.uk";
    public string VenueName { get; init; } = LocationName;
    public string Standard_ActuaryLevel7 { get; init; } = "Actuary (Level 7)";
    public string PostCode { get; init; } = "Tw14 9py";
    public string Website { get; init; } = "www.company.co.uk";
    public string UpdatedWebsite { get; init; } = "www.123company.co.uk";
    public string ContactWebsite { get; init; } = "www.companycontact.co.uk";
    public string ContactNumber { get; init; } = RandomDataGenerator.GenerateRandomNumber(12);
    public StandardsTestData StandardsTestData { get; init; } = new StandardsTestData {LarsCode = "203", StandardName = "Teacher (Level 6)", Venue = LocationName };
}