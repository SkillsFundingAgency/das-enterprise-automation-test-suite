using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper;

public class ApprenticePPIDataHelper
{
    public ApprenticePPIDataHelper(string[] tags) : this(tags, GetCmadPPIData(IsApprenticeCommitments(tags), IsAslistedemployer(tags)))
    {

    }

    public ApprenticePPIDataHelper(string[] tags, DateTime dateOfBirth) : this(tags, ("FLP_", dateOfBirth))
    {

    }

    private ApprenticePPIDataHelper(string[] tags, (string nameprefix, DateTime dateOfBirth) value) => ApprenticeEmail = CreatePPIData(tags, value);

    private string CreatePPIData(string[] tags, (string nameprefix, DateTime dateOfBirth) value)
    {
        var datetime = DateTime.UtcNow;

        string seconds = datetime.ToSeconds();
        string nseconds = datetime.ToNanoSeconds();

        var randomPersonNameHelper = new RandomPersonNameHelper();

        var firstName = randomPersonNameHelper.FirstName;
        var lastName = randomPersonNameHelper.LastName;

        ApprenticeFirstname = $"{value.nameprefix}F_{firstName}_{seconds}";
        ApprenticeLastname = $"{value.nameprefix}L_{lastName}_{nseconds}";

        DateOfBirthDay = value.dateOfBirth.Day;
        DateOfBirthMonth = value.dateOfBirth.Month;
        DateOfBirthYear = value.dateOfBirth.Year;

        string emailPrefix = IsPerfTest(tags) ? "PerfTest_" : string.Empty;

        string emaildomain = IsPerfTest(tags) ? "email.com" : (IsApprenticeCommitments(tags) || IsFlexiPayments(tags)) ? "mailinator.com" : "email.com";

        return $"{emailPrefix}{ApprenticeFirstname}_{ApprenticeLastname}@{emaildomain}";
    }

    public string ApprenticeEmail { get; private set; }

    public string ApprenticeFirstname { get; private set; }

    public string ApprenticeLastname { get; private set; }

    public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

    public int DateOfBirthDay { get; private set; }

    public int DateOfBirthMonth { get; private set; }

    public int DateOfBirthYear { get; private set; }

    public DateTime ApprenticeDob => new(DateOfBirthYear, DateOfBirthMonth, DateOfBirthDay);

    private static (string nameprefix, DateTime dateOfBirth) GetCmadPPIData(bool isApprenticeCommitments, bool isAslistedemployer)
    {
        string namePrefix = isApprenticeCommitments && isAslistedemployer ? $"CMAD_LE_" : isApprenticeCommitments ? $"CMAD_" : string.Empty;

        DateTime dob = new(RandomDataGenerator.GenerateRandomDobYear(), RandomDataGenerator.GenerateRandomMonth(), RandomDataGenerator.GenerateRandomDateOfMonth());

        return (namePrefix, dob);
    }

    private static bool IsApprenticeCommitments(string[] tags) => tags.Contains("apprenticecommitments");
    private static bool IsAslistedemployer(string[] tags) => tags.IsAsListedEmployer();
    private static bool IsFlexiPayments(string[] tags) => tags.Contains("flexi-payments");
    private static bool IsPerfTest(string[] tags) => tags.Contains("perftest");
}
