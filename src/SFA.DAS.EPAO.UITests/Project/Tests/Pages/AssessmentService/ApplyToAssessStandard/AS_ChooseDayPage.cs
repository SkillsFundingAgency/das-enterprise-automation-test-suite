using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ChooseDayPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "If your application is successful, can you start an end-point assessment on the day you join the register?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        private readonly ScenarioContext _context;

        public AS_ChooseDayPage(ScenarioContext context) : base(context) => _context = context;

        public AS_AssessmentPlanPage EnterDayToStart()
        {
            SelectYesAndContinue();
            return new AS_AssessmentPlanPage(_context);
        }
    }
}
