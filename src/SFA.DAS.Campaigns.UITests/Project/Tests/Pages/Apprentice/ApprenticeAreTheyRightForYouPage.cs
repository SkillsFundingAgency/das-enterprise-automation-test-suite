using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeAreTheyRightForYouPage(ScenarioContext context) : ApprenticeBasePage(context)
    {
        protected override string PageTitle => "Are they right for you?";

        public ApprenticeAreTheyRightForYouPage VerifyApprenticeAreTheyRightForYouPageSubHeadings() => VerifyFiuCards(() => NavigateToAreApprenticeShipRightForMe());
    }
}