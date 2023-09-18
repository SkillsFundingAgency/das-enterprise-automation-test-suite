using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice;

public abstract class Apprentice_BaseSteps : AppEmp_BaseSteps
{
    protected BeforeYouStartPage beforeYouStartPage;

    protected CheckYourAnswersPage checkYourAnswersPage;

    protected ApplicationSubmittedPage applicationSubmittedPage;

    protected ShutterPage shutterPage;

    protected Apprentice_NetworkHubPage networkHubPage;

    public Apprentice_BaseSteps(ScenarioContext context) : base(context) { }

    protected SignInPage GetSignInPage() => new(context);
}
