using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage : TransferMatchingBasePage
    {

        protected override string PageTitle => "My transfer pledges";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CreatePledgesSelector => By.CssSelector("[href*='/pledges/create/inform']");

        public MyTransferPledgesPage(ScenarioContext context) : base(context) => _context = context;

        public PledgeAndTransferYourLevyFundsPage CreatePledge()
        {
            formCompletionHelper.Click(CreatePledgesSelector);
            return new PledgeAndTransferYourLevyFundsPage(_context);
        }
    }
}