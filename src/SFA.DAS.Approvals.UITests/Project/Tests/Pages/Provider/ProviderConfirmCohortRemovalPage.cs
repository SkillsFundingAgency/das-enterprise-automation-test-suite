using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortRemovalPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm cohort removal";

        private static By ConfirmDeleteOptions => By.XPath("//label[contains(text(),'Yes, remove cohort')]");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderLearnerRequestsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            Continue();
            return new ProviderLearnerRequestsPage(context);
        }

        public bool IsDeleteOptionDisplayed() => pageInteractionHelper.IsElementDisplayed(ConfirmDeleteOptions);


    }
}
