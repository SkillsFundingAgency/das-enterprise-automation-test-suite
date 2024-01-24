using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ClosePledgePage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => $"Close pledge {GetPledgeId()}";

        protected override string AccessibilityPageTitle => "Close pledge page";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private static By NoSelector => By.CssSelector("#close-pledge-no");

        private static By YesSelector => By.CssSelector("#close-pledge-yes");


        public TransferPledgePage DontClose()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NoSelector);
            Continue();
            return new TransferPledgePage(context);
        }

        public MyTransferPledgesPage ConfirmClose()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesSelector);
            Continue();
            return new MyTransferPledgesPage(context);
        }
    }
}