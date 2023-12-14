using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered include apprenticeship training";

        public ReviewProcessForEvaluatingPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReviewProcessForEvaluatingPage(context);
        }

        public ReviewProcessForEvaluatingPage SelectFailAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
        {
            SelectFailAndContinueToSubSection();
            return new ReviewProcessForEvaluatingPage(context);
        }
    }
}