using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class YourSectorsAndEmployeesPage : AssessorBasePage
    {
        protected override string PageTitle => "Sectors and employee experience";
        private readonly ScenarioContext _context;
        public string DigitalLinkText => "Digital";
        private By DigitalLink => By.LinkText($"{DigitalLinkText}");
        private By GoToApplicationAssessmentOverviewLink => By.LinkText("Go to application assessment overview");

        public YourSectorsAndEmployeesPage(ScenarioContext context) : base(context) => _context = context;

        public DeliveringTrainingInDigitalSectorPage NavigateToDeliveringTrainingInDigitalSectorPage()
        {
            formCompletionHelper.Click(DigitalLink);
            return new DeliveringTrainingInDigitalSectorPage(_context);
        }

        public ApplicationAssessmentOverviewPage NavigateToAssessmentOverviewPage()
        {
            formCompletionHelper.Click(GoToApplicationAssessmentOverviewLink);
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}