using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyApplicationsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public MyApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus)
        {
            formCompletionHelper.ClickLinkByText(GetPledgeId());
            return new ApplicationsDetailsPage(_context, expectedStatus);
        }
    }
}