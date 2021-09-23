using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeAndTransferYourLevyFundsPage : TransferMatchingBasePage
    {

        protected override string PageTitle => "Pledge and transfer your levy funds";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartCreatePledgesSelector => By.CssSelector("[href*='/pledges/create?']");

        public PledgeAndTransferYourLevyFundsPage(ScenarioContext context) : base(context) => _context = context;

        public void StartCreatePledge()
        {
            formCompletionHelper.Click(StartCreatePledgesSelector);

        }
    }
}