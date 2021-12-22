using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm cohort deletion";

        private By ConfirmDeleteOptions => By.XPath("//label[contains(text(),'Yes, delete cohort')]");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderConfirmCohortDeletionPage(ScenarioContext context) : base(context)  { }

        public ProviderApprenticeRequestsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            Continue();
            return new ProviderApprenticeRequestsPage(context);
        }

        public bool IsDeleteOptionDisplayed() => pageInteractionHelper.IsElementDisplayed(ConfirmDeleteOptions);


    }
}
