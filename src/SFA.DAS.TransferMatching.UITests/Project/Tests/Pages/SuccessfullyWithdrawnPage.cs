using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class SuccessfullyWithdrawnPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "You have successfully declined a transfer of funds";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SuccessfullyWithdrawnPage(ScenarioContext context) : base(context) => _context = context;

        public MyApplicationsPage ViewMyApplications()
        {
            formCompletionHelper.ClickLinkByText("View my applications");
            return new MyApplicationsPage(_context);
        }
    }
}
