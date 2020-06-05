using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_StandardSearchResultsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Standard search results";
        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        public AS_StandardSearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConfirmAndApplyPage Apply()
        {
            tableRowHelper.SelectRowFromTable("Apply for standard", standardDataHelper.ApplyforStandard);
            return new AS_ConfirmAndApplyPage(_context);
        }
    }
}