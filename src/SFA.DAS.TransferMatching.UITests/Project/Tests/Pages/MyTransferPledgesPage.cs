using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My transfer pledges";

        private By CreatePledgesSelector => By.CssSelector("[href*='/pledges/create/inform']");

        private By PledgeSelector => By.CssSelector($"a[href='pledges/{GetPledgeId()}/applications']");

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

        public void VerifyPledge() => VerifyPage(PledgeSelector);
    }
}