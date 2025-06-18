using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public abstract class ModerationAssessmentCompletePage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-panel__body");

        private static By GoToRoATPAssessorApplicationsLink => By.LinkText("Go to RoATP assessor applications");

        public RoatpAssessorApplicationsHomePage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPAssessorApplicationsLink);
            return new RoatpAssessorApplicationsHomePage(context);
        }
    }
}