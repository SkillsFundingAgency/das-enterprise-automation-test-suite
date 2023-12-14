using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInDigitalSectorPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Delivering training in 'Digital' sector";

        public YourSectorsAndEmployeesPage SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage()
        {
            SelectPassAndContinueToSubSection();
            return new YourSectorsAndEmployeesPage(context);
        }
    }
}