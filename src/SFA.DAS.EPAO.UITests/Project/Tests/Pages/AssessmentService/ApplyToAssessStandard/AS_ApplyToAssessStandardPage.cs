using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplyToAssessStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apply to assess a standard";
        private readonly ScenarioContext _context;

        private By StartNow => By.CssSelector("a.govuk-button--start");

        public AS_ApplyToAssessStandardPage(ScenarioContext context) : base(context) => _context = context;

        public AS_SelectApplicationPage SelectApplication()
        {
            formCompletionHelper.ClickElement(StartNow);
            return new AS_SelectApplicationPage(_context);
        }
    }
}
