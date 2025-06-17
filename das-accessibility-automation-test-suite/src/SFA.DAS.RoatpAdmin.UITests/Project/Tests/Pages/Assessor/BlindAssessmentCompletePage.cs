using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class BlindAssessmentCompletePage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Blind assessment complete";

        private static By GoToRoATPAssessorApplicationsLink => By.LinkText("Go to RoATP assessor applications");

        public RoatpAssessorApplicationsHomePage GoToRoATPAssessorApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPAssessorApplicationsLink);
            return new RoatpAssessorApplicationsHomePage(context);
        }
    }
}