using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered include apprenticeship training";
        private readonly ScenarioContext _context;

        public ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public ReviewProcessForEvaluatingPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReviewProcessForEvaluatingPage(_context);
        }
    }
}