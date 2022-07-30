namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public record StandardsTestData
{
    public string LarsCode;
    public string StandardName;
}

public class ManagingStandardsDataHelpers
{
    public string EmailAddress { get; init; } = "ManagingStandardstest.demo@digital.education.gov.uk";
    public string Website { get; init; } = "www.company.co.uk";
    public string ContactWebsite { get; init; } = "www.companycontact.co.uk";
    public string ContactNumber { get; init; } = RandomDataGenerator.GenerateRandomNumber(12);
    public StandardsTestData StandardsTestData { get; init; } = new StandardsTestData {LarsCode = "203", StandardName = "Teacher (Level 6)" };
}
