using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfTrainingDeliveredPage : ModeratorBasePage
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered";

        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(ScenarioContext context) : base(context) { }

        public ImprovementsMadeUsingProcessPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
        {
            SelectPassAndContinueToSubSection();
            return new ImprovementsMadeUsingProcessPage(context);
        }

        public ImprovementsMadeUsingProcessPage SelectFailAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
        {
            SelectFailAndContinueToSubSection();
            return new ImprovementsMadeUsingProcessPage(context);
        }
    }
}