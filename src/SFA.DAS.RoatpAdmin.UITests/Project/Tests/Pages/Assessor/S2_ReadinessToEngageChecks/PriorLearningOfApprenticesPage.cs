using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class PriorLearningOfApprenticesPage : AssessorBasePage
    {
        protected override string PageTitle => "Process for initial assessments to recognise prior learning";

        public PriorLearningOfApprenticesPage(ScenarioContext context) : base(context) { }

        public ProcessToAssessEnglishAndMathsPage SelectPassAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(context);
        }
    }
}