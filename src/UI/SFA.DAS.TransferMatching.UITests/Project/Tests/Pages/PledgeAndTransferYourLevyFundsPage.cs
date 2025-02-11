using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeAndTransferYourLevyFundsPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Pledge and transfer your levy funds";

        private static By StartCreatePledgesSelector => By.CssSelector("[href*='/pledges/create?']");

        public CreateATransferPledgePage StartCreatePledge()
        {
            formCompletionHelper.Click(StartCreatePledgesSelector);
            return new CreateATransferPledgePage(context);
        }
    }
}