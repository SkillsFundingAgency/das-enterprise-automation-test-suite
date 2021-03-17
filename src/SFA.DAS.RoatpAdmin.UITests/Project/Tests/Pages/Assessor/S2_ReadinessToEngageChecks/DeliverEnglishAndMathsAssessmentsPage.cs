using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class DeliverEnglishAndMathsAssessmentsPage : AssessorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        private readonly ScenarioContext _context;

        public DeliverEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public SignificantEventEnglishAndMathsAssessmentsPage SelectPassAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectPassAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(_context);
        }
    }
}