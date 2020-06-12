using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_SelectApplicationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Select application";
        private readonly ScenarioContext _context;

        private By StartApplicationLink => By.CssSelector("#main-content .govuk-button[type='submit']");

        public AS_SelectApplicationPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplyForAStandardPage StartApplication()
        {
            formCompletionHelper.ClickElement(StartApplicationLink);
            return new AS_ApplyForAStandardPage(_context);
        }

        public AS_ApplicationOverviewPage SelectApplication()
        {
            tableRowHelper.SelectRowFromTable("View", objectContext.GetApplyStandardName());
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}
