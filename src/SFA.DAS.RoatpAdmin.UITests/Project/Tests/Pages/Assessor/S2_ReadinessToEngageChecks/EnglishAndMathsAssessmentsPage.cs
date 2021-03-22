using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage : AssessorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        private readonly ScenarioContext _context;

        public EnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public DeliverEnglishAndMathsAssessmentsPage SelectPassAndContinueForEnglishAndMathsAssessment()
        {
            SelectPassAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(_context);
        }
    }
}