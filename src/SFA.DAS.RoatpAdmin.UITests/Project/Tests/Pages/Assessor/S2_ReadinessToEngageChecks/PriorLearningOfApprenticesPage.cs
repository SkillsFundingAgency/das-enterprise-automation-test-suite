using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class PriorLearningOfApprenticesPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Process for initial assessments to recognise prior learning";

        public ProcessToAssessEnglishAndMathsPage SelectPassAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(context);
        }
    }
}