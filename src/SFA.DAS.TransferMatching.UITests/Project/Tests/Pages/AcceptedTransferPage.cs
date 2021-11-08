using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AcceptedTransferPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "You have successfully accepted a transfer";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AcceptedTransferPage(ScenarioContext context) : base(context) => _context = context;

        public MyApplicationsPage ViewMyApplications()
        {
            formCompletionHelper.ClickLinkByText("View my applications");
            return new MyApplicationsPage(_context);
        }

    }
}