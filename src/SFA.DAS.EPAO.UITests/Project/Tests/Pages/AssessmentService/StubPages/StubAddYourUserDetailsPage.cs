using SFA.DAS.Login.Service.Project.Tests.Pages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;

public class StubAddYourUserDetailsPage : StubAddYourUserDetailsBasePage
{
    public StubAddYourUserDetailsPage(ScenarioContext context) : base(context) { }

    public AS_ConfirmYourIdentityPage EnterAccountDetailsAndClickCreateAccount(EPAOAssesorCreateUserDataHelper dataHelper)
    {
        EnterNameAndContinue(dataHelper.GivenName, dataHelper.FamilyName);

        return new(context);
    }
}
