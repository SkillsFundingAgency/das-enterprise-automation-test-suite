using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmChangesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm changes";
        private static By ConfirmChangesRadio => By.CssSelector("#ConfirmChanges");
        private static By FinishButton => By.CssSelector("#submit-confirm-change");

        public ApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmChangesRadio);
            formCompletionHelper.ClickElement(FinishButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}