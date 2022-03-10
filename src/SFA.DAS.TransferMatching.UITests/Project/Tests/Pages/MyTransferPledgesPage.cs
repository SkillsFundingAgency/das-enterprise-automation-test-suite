using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My transfer pledges";

        private By CreatePledgesSelector => By.CssSelector("[href*='/pledges/create/inform']");

        private By PledgeSelector => By.CssSelector($"a[href='pledges/{GetPledgeId()}/applications']");
        private By ActiveStatusSelector => By.CssSelector("#main-content > div > div > div.govuk-grid-column-two-thirds > table > tbody > tr > td:nth-child(5) > strong");
        private By ClosedStatusSelector => By.CssSelector("#main-content > div > div:nth-child(2) > div.govuk-grid-column-two-thirds > table > tbody > tr:nth-child(2) > td:nth-child(5) > strong");
        public MyTransferPledgesPage(ScenarioContext context) : base(context) { }

        public TransferPledgePage GoToTransferPledgePage()
        {
            formCompletionHelper.Click(PledgeSelector);
            return new TransferPledgePage(context);
        }

        public PledgeAndTransferYourLevyFundsPage CreatePledge()
        {
            formCompletionHelper.Click(CreatePledgesSelector);
            return new PledgeAndTransferYourLevyFundsPage(context);
        }
        public MyTransferPledgesPage ConfirmCloseStatus()
        {
            pageInteractionHelper.IsElementDisplayed(ClosedStatusSelector);
            return new MyTransferPledgesPage(context);
        }
        public MyTransferPledgesPage ConfirmActiveStatus()
        {
            pageInteractionHelper.IsElementDisplayed(ActiveStatusSelector);
            return new MyTransferPledgesPage(context);
        }

        public void VerifyPledge() => VerifyElement(PledgeSelector);

    }
}