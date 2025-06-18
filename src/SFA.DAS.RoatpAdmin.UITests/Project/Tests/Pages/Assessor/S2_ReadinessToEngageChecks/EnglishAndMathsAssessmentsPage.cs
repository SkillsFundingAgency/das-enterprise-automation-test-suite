using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "English and maths assessments";

        public DeliverEnglishAndMathsAssessmentsPage SelectPassAndContinueForEnglishAndMathsAssessment()
        {
            SelectPassAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(context);
        }
    }
}