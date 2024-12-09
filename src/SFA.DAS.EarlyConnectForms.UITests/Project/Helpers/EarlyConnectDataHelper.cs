using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;

public class EarlyConnectDataHelper
{
    public EarlyConnectDataHelper(string email, string name)
    {
        var randomPersonNameHelper = new RandomPersonNameHelper();
        Firstname = randomPersonNameHelper.FirstName;
        Lastname = randomPersonNameHelper.LastName;
        DateOfBirthDay = RandomDataGenerator.GenerateRandomDateOfMonth();
        DateOfBirthMonth = RandomDataGenerator.GenerateRandomMonth();
        DateOfBirthYear = RandomDataGenerator.GenerateRandomDobYear();
        TelephoneNumber = $"077{RandomDataGenerator.GenerateRandomNumber(8)}";
        Email = email;
        SchoolOrCollegeName = name;
    }

    public string TelephoneNumber { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public string Email { get; }
    public int DateOfBirthDay { get; set; }
    public int DateOfBirthMonth { get; set; }
    public int DateOfBirthYear { get; set; }
    public string PostCode { get; init; } = RandomDataGenerator.RandomPostCode();
    public string SchoolOrCollegeName { get; init; }
    public string SearchInvalidSchoolCollege { get; set; } = "Invalid selection";
}
