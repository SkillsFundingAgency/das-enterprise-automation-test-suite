using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class DeliverEnglishAndMathsAssessmentsPage : ModeratorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        
        public DeliverEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) { }

        public SignificantEventEnglishAndMathsAssessmentsPage SelectPassAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectPassAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(_context);
        }
        public SignificantEventEnglishAndMathsAssessmentsPage SelectFailAndContinueForWhereWillYouDeliverEnglishAndMathsAssessments()
        {
            SelectFailAndContinueToSubSection();
            return new SignificantEventEnglishAndMathsAssessmentsPage(_context);
        }
    }
}