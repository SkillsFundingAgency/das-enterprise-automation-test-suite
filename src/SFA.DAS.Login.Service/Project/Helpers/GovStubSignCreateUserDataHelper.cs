using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Login.Service.Project.Helpers;

public abstract class GovStubSignCreateUserDataHelper
{
    public GovStubSignCreateUserDataHelper()
    {
        var randomPersonNameHelper = new RandomPersonNameHelper();

        GivenName = randomPersonNameHelper.FirstName;
        FamilyName = $"{randomPersonNameHelper.LastName}+{DateTimeExtension.GetDateTimeValue()}";
        CreateAccountEmail = $"{GivenName}_{FamilyName}@mailinator.com";
    }

    public string GivenName { get; protected set; }
    public string FamilyName { get; protected set; }
    public string CreateAccountEmail { get; protected set; }
}
