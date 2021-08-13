using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeAreTheyRightForYouPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Are they right for you?";

        public ApprenticeAreTheyRightForYouPage(ScenarioContext context) : base(context) { }

        public ApprenticeAreTheyRightForYouPage VerifyApprenticeAreTheyRightForYouPageSubHeadings() => VerifyFiuCards(() => NavigateToAreApprenticeShipRightForMe());
    }
}