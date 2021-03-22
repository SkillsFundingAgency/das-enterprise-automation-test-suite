using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class SignificantEventEnglishAndMathsAssessmentsPage : AssessorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        private readonly ScenarioContext _context;

        public SignificantEventEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage SelectPassAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}