namespace SFA.DAS.TestDataExport.Helper;

public class ApprenticePPIDataHelper
{
    public ApprenticePPIDataHelper(string[] tags, string emailDomain) : this(tags, GetCmadPPIData(IsApprenticeCommitments(tags), IsAslistedemployer(tags)), emailDomain)
    {

    }

    public ApprenticePPIDataHelper(string[] tags, DateTime dateOfBirth, string emailDomain) : this(tags, ("FLP_", dateOfBirth), emailDomain)
    {

    }

    private ApprenticePPIDataHelper(string[] tags, (string nameprefix, DateTime dateOfBirth) value, string emailDomain) => ApprenticeEmail = CreatePPIData(tags, value, emailDomain);

    private string CreatePPIData(string[] tags, (string nameprefix, DateTime dateOfBirth) value, string emailDomain)
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

        string _emailDomain = IsPerfTest(tags) ? "email.com" : emailDomain;

        return $"{emailPrefix}{ApprenticeFirstname}_{ApprenticeLastname}@{_emailDomain}";
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
