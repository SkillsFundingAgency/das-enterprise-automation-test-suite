using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class PriorLearningOfApprenticesPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Process for initial assessments to recognise prior learning";

        public ProcessToAssessEnglishAndMathsPage SelectPassAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(context);
        }

        public ProcessToAssessEnglishAndMathsPage SelectFailAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectFailAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(context);
        }
    }
}