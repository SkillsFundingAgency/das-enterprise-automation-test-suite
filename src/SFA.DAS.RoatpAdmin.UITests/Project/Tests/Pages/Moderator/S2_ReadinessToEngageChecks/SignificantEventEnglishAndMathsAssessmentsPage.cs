using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class SignificantEventEnglishAndMathsAssessmentsPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "English and maths assessments";

        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectFailAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectFailAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(context);
        }
    }
}