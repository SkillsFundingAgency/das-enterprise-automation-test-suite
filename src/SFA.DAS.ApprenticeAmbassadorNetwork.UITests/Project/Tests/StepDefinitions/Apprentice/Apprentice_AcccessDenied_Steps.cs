using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice;

[Binding, Scope(Tag = "@aanaprentice")]
public class Apprentice_AcccessDenied_Steps(ScenarioContext context) : Apprentice_BaseSteps(context)
{
    [Given(@"the non Private beta apprentice logs into AAN portal")]
    public void GivenTheNonPrivateBetaApprenticeLogsIntoAANPortal() =>  new SignInPage(context).NonPrivateBetaUserDetails(context.Get<AanApprenticeNonBetaUser>());

    [Then(@"an Access Denied page should be displayed")]
    public void ThenAccessDeniedPageShouldBeDisplayed() =>
     new BeforeYouStartPage(context).StartApprenticeOnboardingJourney()
        .AcceptTermsAndConditions()
        .YesHaveApprovalFromMaanagerAndNonPrivateBetaUser()
        .VerifyHomeLink();
}
