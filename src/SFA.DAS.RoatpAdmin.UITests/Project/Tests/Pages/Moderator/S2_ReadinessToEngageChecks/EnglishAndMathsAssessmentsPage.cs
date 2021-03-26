using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage : ModeratorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        private readonly ScenarioContext _context;

        public EnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public DeliverEnglishAndMathsAssessmentsPage SelectPassAndContinueForEnglishAndMathsAssessment()
        {
            SelectPassAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(_context);
        }
        public DeliverEnglishAndMathsAssessmentsPage SelectFailAndContinueForEnglishAndMathsAssessment()
        {
            SelectFailAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(_context);
        }
    }
}