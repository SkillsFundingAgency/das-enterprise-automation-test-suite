using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Process for evaluating the quality of training delivered include apprenticeship training";

        public ReviewProcessForEvaluatingPage SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReviewProcessForEvaluatingPage(context);
        }
    }
}