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
    }
}
