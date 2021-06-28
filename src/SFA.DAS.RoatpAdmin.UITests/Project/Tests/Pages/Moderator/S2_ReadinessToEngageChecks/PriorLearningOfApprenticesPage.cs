using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class PriorLearningOfApprenticesPage : ModeratorBasePage
    {
        protected override string PageTitle => "Process for initial assessments to recognise prior learning";
        private readonly ScenarioContext _context;

        public PriorLearningOfApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public ProcessToAssessEnglishAndMathsPage SelectPassAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(_context);
        }

        public ProcessToAssessEnglishAndMathsPage SelectFailAndContinueInPriorLearningOfApprenticesPage()
        {
            SelectFailAndContinueToSubSection();
            return new ProcessToAssessEnglishAndMathsPage(_context);
        }
    }
}