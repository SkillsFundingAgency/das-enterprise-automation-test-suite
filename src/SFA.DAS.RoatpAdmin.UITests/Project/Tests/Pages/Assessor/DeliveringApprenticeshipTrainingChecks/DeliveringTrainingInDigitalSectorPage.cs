using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInDigitalSectorPage : AssessorBasePage
    {
        protected override string PageTitle => "Delivering training in 'Digital' sector";
        private readonly ScenarioContext _context;

        public DeliveringTrainingInDigitalSectorPage(ScenarioContext context) : base(context) => _context = context;

        public YourSectorsAndEmployeesPage SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage()
        {
            SelectPassAndContinueToSubSection();
            return new YourSectorsAndEmployeesPage(_context);
        }
    }
}