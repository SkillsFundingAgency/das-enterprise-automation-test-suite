using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortDeletionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm cohort deletion";

        private By ConfirmDeleteOptions => By.Id("confirm-true");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmCohortDeletionPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderYourCohortsPage ConfirmDeleteAndSubmit()
        {
            javaScriptHelper.ClickElement(ConfirmDeleteOptions);
            Continue();
            return new ProviderYourCohortsPage(_context);
        }
    }
}
