using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice
{
    public abstract class Apprentice_BaseSteps : BaseSteps
    {
        protected BeforeYouStartPage beforeYouStartPage;

        protected CheckYourAnswersPage checkYourAnswersPage;

        protected ApplicationSubmittedPage applicationSubmittedPage;

        protected ShutterPage shutterPage;

        protected Apprentice_NetworkHubPage networkHubPage;

        protected EventPage eventPage;

        protected SearchNetworkEventsPage searchNetworkEventsPage;

        public Apprentice_BaseSteps(ScenarioContext context) : base(context) { }

        protected SignInPage GetSignInPage() => new(context);
    }
}
