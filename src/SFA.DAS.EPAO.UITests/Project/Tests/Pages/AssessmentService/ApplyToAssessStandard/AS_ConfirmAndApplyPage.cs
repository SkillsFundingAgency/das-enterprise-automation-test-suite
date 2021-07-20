using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ConfirmAndApplyPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm you want to offer the standard";
        private readonly ScenarioContext _context;

        protected override By PageHeader => By.CssSelector(".govuk-caption-l");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        private By ConfirmCheckBox => By.CssSelector("#IsConfirmed");

        private By VersionCheckBox => By.Name("SelectedVersions");

        public AS_ConfirmAndApplyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplicationOverviewPage ConfirmAndApply()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmCheckBox));
            Continue();
            return new AS_ApplicationOverviewPage(_context);
        }

        public AS_ApplicationOverviewPage ConfirmAndApplyWithVersion()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(VersionCheckBox));
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ConfirmCheckBox));
            Continue();
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}