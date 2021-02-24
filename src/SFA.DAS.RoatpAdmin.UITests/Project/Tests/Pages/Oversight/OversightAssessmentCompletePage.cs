using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightAssessmentCompletePage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Overall outcome saved";
        private By GoToRoATPApplicationOutcomeLink => By.LinkText("Go to RoATP application outcomes");

        private readonly ScenarioContext _context;

        public OversightAssessmentCompletePage(ScenarioContext context) : base(context) => _context = context;

        public OversightLandingPage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPApplicationOutcomeLink);
            return new OversightLandingPage(_context);
        }
    }
}
