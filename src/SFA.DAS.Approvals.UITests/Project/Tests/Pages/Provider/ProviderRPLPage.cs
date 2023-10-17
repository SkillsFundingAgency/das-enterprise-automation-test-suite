using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderRPLPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Recognition of prior learning (RPL)";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ProviderRPLPage(ScenarioContext context) : base(context) { }

        public void SelectNoAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
        }

        public ProviderRPLDetailsPage SelectYesAndContinue()
        {
            SelectYes();
            return new ProviderRPLDetailsPage(context);
        }

        public WhitelistedProviderRPLDetailsPage SelectYesAndContinue_WhiteListed()
        {
            SelectYes();
            return new WhitelistedProviderRPLDetailsPage(context);
        }

        private void SelectYes()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
        }
    }
}
