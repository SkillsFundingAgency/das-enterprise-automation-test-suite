using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "English and maths assessments";

        public DeliverEnglishAndMathsAssessmentsPage SelectPassAndContinueForEnglishAndMathsAssessment()
        {
            SelectPassAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(context);
        }
        public DeliverEnglishAndMathsAssessmentsPage SelectFailAndContinueForEnglishAndMathsAssessment()
        {
            SelectFailAndContinueToSubSection();
            return new DeliverEnglishAndMathsAssessmentsPage(context);
        }
    }
}