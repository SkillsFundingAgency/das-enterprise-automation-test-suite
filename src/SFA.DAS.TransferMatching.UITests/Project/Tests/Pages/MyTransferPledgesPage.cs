using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyTransferPledgesPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My transfer pledges";

        private static By CreatePledgesSelector => By.CssSelector("[href*='/pledges/create/inform']");
        private By PledgeSelector => By.CssSelector($"a[href='pledges/{GetPledgeId()}/applications']");
        private static By ActiveStatusSelector => By.TagName("govuk-tag govuk-tag--dark-blue");
        private static By ClosedStatusSelector => By.TagName("govuk-tag govuk-tag--grey");
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