using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortDeletionPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm cohort deletion";

        private static By ConfirmDeleteOptions => By.XPath("//label[contains(text(),'Yes, delete cohort')]");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderApprenticeRequestsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            Continue();
            return new ProviderApprenticeRequestsPage(context);
        }

        public bool IsDeleteOptionDisplayed() => pageInteractionHelper.IsElementDisplayed(ConfirmDeleteOptions);


    }
}
