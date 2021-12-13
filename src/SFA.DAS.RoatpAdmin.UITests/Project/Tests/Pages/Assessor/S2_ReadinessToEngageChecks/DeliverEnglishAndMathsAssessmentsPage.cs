using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class DeliverEnglishAndMathsAssessmentsPage : AssessorBasePage
    {
        protected override string PageTitle => "English and maths assessments";

        public DeliverEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) { }

        public SignificantEventEnglishAndMathsAssessmentsPage SelectPassAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectPassAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(_context);
        }
    }
}