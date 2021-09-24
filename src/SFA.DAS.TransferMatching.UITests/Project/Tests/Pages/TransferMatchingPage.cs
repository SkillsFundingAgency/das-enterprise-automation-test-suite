using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferMatchingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Transfers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TransferMatchingPage(ScenarioContext context) : base(context) => _context = context;

        public MyTransferPledgesPage ViewPledges()
        {
            formCompletionHelper.ClickLinkByText("View my transfer pledges and applications");
            return new MyTransferPledgesPage(_context);
        }
    }
}