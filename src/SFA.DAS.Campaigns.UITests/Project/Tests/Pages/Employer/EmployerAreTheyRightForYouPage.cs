using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerAreTheyRightForYouPage: EmployerBasePage
    {
        protected override string PageTitle => "Are they right for you?";

        public EmployerAreTheyRightForYouPage(ScenarioContext context): base(context) { }

        public void VerifyApprenticeHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToAreTheyRightForYouPage());
    }
}