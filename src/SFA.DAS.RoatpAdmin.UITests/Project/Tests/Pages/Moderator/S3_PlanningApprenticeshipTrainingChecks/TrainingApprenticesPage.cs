using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TrainingApprenticesPage : ModeratorBasePage
    {
        protected override string PageTitle => "How apprentices will be trained";
        private readonly ScenarioContext _context;

        public TrainingApprenticesPage(ScenarioContext context) : base(context) => _context = context;
    }
}