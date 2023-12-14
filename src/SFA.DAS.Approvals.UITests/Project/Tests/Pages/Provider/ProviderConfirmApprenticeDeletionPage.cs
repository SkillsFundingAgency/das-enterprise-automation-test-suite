using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeletionPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm apprentice deletion";

        private static By ConfirmDeleteOptions => By.Id("confirm-true");
        private static By SaveAndContinueButton => By.Id("saveBtn");

        internal ProviderApproveApprenticeDetailsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
