using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyApplicationsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My applications";

        public MyApplicationsPage(ScenarioContext context) : base(context) { }

        public ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus)
        {
            formCompletionHelper.ClickLinkByText(GetPledgeId());
            return new ApplicationsDetailsPage(_context, expectedStatus);
        }
    }
}