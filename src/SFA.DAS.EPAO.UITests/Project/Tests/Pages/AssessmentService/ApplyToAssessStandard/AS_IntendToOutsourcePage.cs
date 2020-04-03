using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_IntendToOutsourcePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Do you intend to outsource any of your end-point assessments?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        private readonly ScenarioContext _context;

        public AS_IntendToOutsourcePage(ScenarioContext context) : base(context) => _context = context;

        public AS_EngageWithEmployersPage EnterIntendToOutsource()
        {
            SelectAndContinue("No");
            return new AS_EngageWithEmployersPage(_context);
        }
    }
}
