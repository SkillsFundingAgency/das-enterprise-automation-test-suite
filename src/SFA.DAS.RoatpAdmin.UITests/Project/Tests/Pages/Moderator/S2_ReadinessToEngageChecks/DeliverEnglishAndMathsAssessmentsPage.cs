using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class DeliverEnglishAndMathsAssessmentsPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "English and maths assessments";

        public SignificantEventEnglishAndMathsAssessmentsPage SelectPassAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectPassAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(context);
        }
        public SignificantEventEnglishAndMathsAssessmentsPage SelectFailAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectFailAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(context);
        }
    }
}