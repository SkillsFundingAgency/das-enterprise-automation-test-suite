using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages;

public class StubAddYourUserDetailsPage(ScenarioContext context) : StubAddYourUserDetailsBasePage(context)
{
    public EnterUkprnPage EnterNameAndContinue(RoatpApplyCreateUserDataHelper dataHelper)
    {
        EnterNameAndContinue(dataHelper.GivenName, dataHelper.FamilyName);

        return new EnterUkprnPage(context);
    }
}
