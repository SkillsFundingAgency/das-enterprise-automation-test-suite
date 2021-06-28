using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class BlindAssessmentCompletePage : AssessorBasePage
    {
        protected override string PageTitle => "Blind assessment complete";
        private readonly ScenarioContext _context;
        private By GoToRoATPAssessorApplicationsLink => By.LinkText("Go to RoATP assessor applications");

        public BlindAssessmentCompletePage(ScenarioContext context) : base(context) => _context = context;

        public RoatpAssessorApplicationsHomePage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPAssessorApplicationsLink);
            return new RoatpAssessorApplicationsHomePage(_context);
        }
    }
}