using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class EnglishAndMathsAssessmentsPage : ModeratorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        
        public EnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) { }

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