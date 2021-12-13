using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage : AssessorBasePage
    {
        protected override string PageTitle => "English and maths assessments";

        public EnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) { }

        public DeliverEnglishAndMathsAssessmentsPage SelectPassAndContinueForEnglishAndMathsAssessment()
        {
            SelectPassAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(_context);
        }
    }
}