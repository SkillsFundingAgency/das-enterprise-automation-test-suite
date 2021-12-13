using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class SignificantEventEnglishAndMathsAssessmentsPage : ModeratorBasePage
    {
        protected override string PageTitle => "English and maths assessments";
        
        public SignificantEventEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) { }

        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectFailAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectFailAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
    }
}