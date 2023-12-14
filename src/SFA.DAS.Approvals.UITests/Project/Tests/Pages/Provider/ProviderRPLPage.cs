using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderRPLPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Recognition of prior learning (RPL)";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public void SelectNoAndContinue()
        {
            SelectAndContinue("No");
        }

        public AddRPLDetailsPage SelectYesAndContinue()
        {
            SelectAndContinue("Yes");

            return new AddRPLDetailsPage(context);
        }

        private void SelectAndContinue(string x)
        {
            formCompletionHelper.SelectRadioOptionByText(x);
            Continue();
        }
    }
}
