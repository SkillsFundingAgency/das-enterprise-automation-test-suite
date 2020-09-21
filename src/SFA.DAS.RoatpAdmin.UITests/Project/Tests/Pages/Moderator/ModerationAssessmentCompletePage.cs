using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationAssessmentCompletePage : ModeratorBasePage
    {
        protected override string PageTitle => "Blind assessment complete";
        private readonly ScenarioContext _context;
        private By GoToRoATPAssessorApplicationsLink => By.LinkText("Go to RoATP assessor applications");

        public ModerationAssessmentCompletePage(ScenarioContext context) : base(context) => _context = context;

        public ModerationApplicationsPage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPAssessorApplicationsLink);
            return new ModerationApplicationsPage(_context);
        }
    }
}