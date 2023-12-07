using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;

public class RoatpApplyCreateUserDataHelper : GovStubSignCreateUserDataHelper
{
    // This parameterless constructor is used to create instance from a specflow table
    public RoatpApplyCreateUserDataHelper()
    {

    }

    public void UpdateData(RoatpApplyCreateUserDataHelper data)
    {
        GivenName = data.GivenName;

        FamilyName = $"{data.FamilyName}";

        CreateAccountEmail = $"{GivenName}{FamilyName}@digital.education.gov.uk";
    }
}
