using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerAreTheyRightForYouPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Are they right for you?";

        public void VerifyApprenticeHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToAreTheyRightForYouPage());
    }
}