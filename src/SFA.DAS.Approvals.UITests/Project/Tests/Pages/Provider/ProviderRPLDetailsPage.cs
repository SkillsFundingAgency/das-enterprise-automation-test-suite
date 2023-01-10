using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderRPLDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Provide recognition of prior learning (RPL) details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By ReducedDurationTextBox => By.Id("ReducedDuration");
        private static By ReducedPriceTextBox => By.Id("ReducedPrice");

        public ProviderRPLDetailsPage(ScenarioContext context) : base(context) { }

        public void EnterRPLDataAndContinue()
        {
            formCompletionHelper.EnterText(ReducedDurationTextBox, 20);
            formCompletionHelper.EnterText(ReducedPriceTextBox, 200);
            Continue();
        }
    }
}
