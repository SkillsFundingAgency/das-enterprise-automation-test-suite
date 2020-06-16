using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ReadinessToEngageChecks
{
    public class PriorLearningOfApprenticesPage : AssessorBasePage
    {
        protected override string PageTitle => "Process for initial assessments to recognise prior learning";
        private readonly ScenarioContext _context;

        public PriorLearningOfApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public ProcessToAssessEnglishAndMathsPage SelectPassAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(_context);
        }
    }
}