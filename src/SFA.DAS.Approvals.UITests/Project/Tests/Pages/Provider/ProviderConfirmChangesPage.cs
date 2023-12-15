using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmChangesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm changes";

        private static By AcceptChangesOptions => By.Id("ConfirmChanges");
        private static By FinishButton => By.Id("submit-confirm-change");

        public ProviderApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            javaScriptHelper.ClickElement(AcceptChangesOptions);
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(context);
        }

    }
}
