using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class YourSectorsAndEmployeesPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Sectors and employee experience";
        public static string DigitalLinkText => "Digital";
        private static By DigitalLink => By.LinkText($"{DigitalLinkText}");
        private static By GoToApplicationAssessmentOverviewLink => By.LinkText("Go to application assessment overview");

        public DeliveringTrainingInDigitalSectorPage NavigateToDeliveringTrainingInDigitalSectorPage()
        {
            formCompletionHelper.Click(DigitalLink);
            return new DeliveringTrainingInDigitalSectorPage(context);
        }

        public ModerationApplicationAssessmentOverviewPage NavigateToAssessmentOverviewPage()
        {
            formCompletionHelper.Click(GoToApplicationAssessmentOverviewLink);

            return new ModerationApplicationAssessmentOverviewPage(context);
        }
    }
}