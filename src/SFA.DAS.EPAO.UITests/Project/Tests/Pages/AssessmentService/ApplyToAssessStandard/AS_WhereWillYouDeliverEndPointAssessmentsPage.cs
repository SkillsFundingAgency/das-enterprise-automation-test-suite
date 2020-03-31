using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_WhereWillYouDeliverEndPointAssessmentsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Where will you deliver end-point assessments?";

        private readonly ScenarioContext _context;

        protected By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input");

        public AS_WhereWillYouDeliverEndPointAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ChooseDayPage ChooseLocation()
        {
            ClickRandomElement(DeliveryAreas);
            Continue();
            return new AS_ChooseDayPage(_context);
        }
    }
}
