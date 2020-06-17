using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfTrainingDeliveredPage : AssessorBasePage
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered";
        private readonly ScenarioContext _context;

        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(ScenarioContext context) : base(context) => _context = context;

        public ImprovementsMadeUsingProcessPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
        {
            SelectPassAndContinueToSubSection();
            return new ImprovementsMadeUsingProcessPage(_context);
        }
    }
}