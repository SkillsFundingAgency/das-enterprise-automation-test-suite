using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class SignificantEventEnglishAndMathsAssessmentsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "English and maths assessments";

        public ApplicationAssessmentOverviewPage SelectPassAndContinueForDeliveringEnglishAndMathsDuringSignificantEvent()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(context);
        }
    }
}