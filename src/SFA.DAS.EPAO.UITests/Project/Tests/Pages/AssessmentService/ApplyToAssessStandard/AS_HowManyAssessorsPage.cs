using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_HowManyAssessorsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How many assessors will you have?";

        private readonly ScenarioContext _context;

        private By InputNumber => By.CssSelector(".govuk-input[type='number']");

        public AS_HowManyAssessorsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_HowManyEndPointAssessmentPage EnterHowManyAssessors()
        {
            formCompletionHelper.EnterText(InputNumber, standardDataHelper.GenerateRandomWholeNumber(1));
            Continue();
            return new AS_HowManyEndPointAssessmentPage(_context);
        }
    }
}
