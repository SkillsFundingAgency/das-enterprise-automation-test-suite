using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ManageTransferMatchingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Manage transfers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CreateTransferPledgeSelector => By.LinkText("Create a transfers pledge");

        public ManageTransferMatchingPage(ScenarioContext context) : base(context) => _context = context;

        public PledgeAndTransferYourLevyFundsPage GotoCreateTransfersPledgePage()
        {
            formCompletionHelper.Click(CreateTransferPledgeSelector);
            return new PledgeAndTransferYourLevyFundsPage(_context);
        }

        public MyTransferPledgesPage GoToViewMyTransferPledgePage()
        {
            formCompletionHelper.ClickLinkByText("View my transfer pledges and applications");
            return new MyTransferPledgesPage(_context);
        }

        public bool CanCreateTransferPledge() => pageInteractionHelper.IsElementDisplayed(CreateTransferPledgeSelector);
    }
}