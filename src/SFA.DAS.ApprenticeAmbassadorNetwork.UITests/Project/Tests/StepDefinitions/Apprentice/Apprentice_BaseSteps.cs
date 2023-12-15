using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice;

public abstract class Apprentice_BaseSteps(ScenarioContext context) : AppEmp_BaseSteps(context)
{
    protected BeforeYouStartPage beforeYouStartPage;

    protected CheckYourAnswersPage checkYourAnswersPage;

    protected RegistrationCompletePage applicationSubmittedPage;

    protected ShutterPage shutterPage;

    protected Apprentice_NetworkHubPage networkHubPage;

    protected SignInPage GetSignInPage() => new(context);
}
