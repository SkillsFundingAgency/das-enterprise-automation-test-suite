using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplicationSubmittedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Stage 2 of your application has been submitted";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        private readonly ScenarioContext _context;

        public AS_ApplicationSubmittedPage(ScenarioContext context) : base(context) => _context = context;

    }
}
