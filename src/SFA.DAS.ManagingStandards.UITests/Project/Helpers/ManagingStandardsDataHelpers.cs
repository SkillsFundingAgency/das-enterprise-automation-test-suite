namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers;

public class ManagingStandardsDataHelpers
{
    public ManagingStandardsDataHelpers()
    {
        Website = "www.company.co.uk";
        ContactWebsite = "www.companycontact.co.uk";
        ContactNumber = RandomDataGenerator.GenerateRandomNumber(12);
        EmailAddress = "ManagingStandardstest.demo@digital.education.gov.uk";
    }
    public string EmailAddress { get; }
    public string Website { get; }
    public string ContactWebsite { get; }
    public string ContactNumber { get; }
}
