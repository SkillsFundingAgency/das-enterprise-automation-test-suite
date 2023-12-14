using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class YourSectorsAndEmployeesPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Sectors and employee experience";
        public static string DigitalLinkText => "Digital";
        private By DigitalLink => By.LinkText($"{DigitalLinkText}");
        private static By GoToApplicationAssessmentOverviewLink => By.LinkText("Go to application assessment overview");

        public DeliveringTrainingInDigitalSectorPage NavigateToDeliveringTrainingInDigitalSectorPage()
        {
            formCompletionHelper.Click(DigitalLink);
            return new DeliveringTrainingInDigitalSectorPage(context);
        }

        public ApplicationAssessmentOverviewPage NavigateToAssessmentOverviewPage()
        {
            formCompletionHelper.Click(GoToApplicationAssessmentOverviewLink);
            return new ApplicationAssessmentOverviewPage(context);
        }
    }
}