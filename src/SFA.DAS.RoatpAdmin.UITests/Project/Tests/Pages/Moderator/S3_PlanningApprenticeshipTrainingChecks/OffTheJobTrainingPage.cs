using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class OffTheJobTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Methods used to deliver 20% off the job training";
        private readonly ScenarioContext _context;

        public OffTheJobTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage SelectPassAndContinueInOffTheJobTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage(_context);
        }
    }
}