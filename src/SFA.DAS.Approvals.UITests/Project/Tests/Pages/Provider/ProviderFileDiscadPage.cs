using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileDiscadPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.Id("saveBtn");

        protected static By ConfirmTrueRadioButton => By.Id("confirm-true");
        protected static By ConfirmFalseRadioButton => By.Id("confirm-false");

        protected override string PageTitle => "Are you sure you want to discard this file?";

        internal void SelectYesAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmTrueRadioButton);
            Continue();
        }

        internal void SelectNoAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmFalseRadioButton);
            Continue();
        }
    }
}
