using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInDigitalSectorPage : ModeratorBasePage
    {
        protected override string PageTitle => "Delivering training in 'Digital' sector";
        
        public DeliveringTrainingInDigitalSectorPage(ScenarioContext context) : base(context) { }

        public YourSectorsAndEmployeesPage SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage()
        {
            SelectPassAndContinueToSubSection();
            return new YourSectorsAndEmployeesPage(context);
        }

        public YourSectorsAndEmployeesPage SelectFailAndContinueInDeliveringTrainingInDigitalSectorPage()
        {
            SelectFailAndContinueToSubSection();
            return new YourSectorsAndEmployeesPage(context);
        }
    }
}