using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfTrainingDeliveredPage : AssessorBasePage
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered";
        
        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(ScenarioContext context) : base(context) { }

        public ImprovementsMadeUsingProcessPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
        {
            SelectPassAndContinueToSubSection();
            return new ImprovementsMadeUsingProcessPage(_context);
        }
    }
}