using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm apprentice deletion";

        private By ConfirmDeleteOptions => By.Id("confirm-true");
        private By SaveAndContinueButton => By.Id("saveBtn");

        public ProviderConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)  { }

        internal ProviderApproveApprenticeDetailsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApproveApprenticeDetailsPage(_context);
        }
    }
}
