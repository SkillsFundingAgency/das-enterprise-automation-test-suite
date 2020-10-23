using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section1Helper
    {
        private readonly ScenarioContext _context;

        public Moderator_Section1Helper(ScenarioContext context) => _context = context;

        public ModerationApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01") || _context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section1_ContinuityPlanForApprenticeshipTraining()
                    .SelectPassAndContinue()
                    .VerifySection1Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection1Link1Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_EqualityAndDiversityPolicy()
                .SelectPassAndContinue()
                .VerifySection1Link2Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_SafeguardingAndPreventDutyPolicy()
                .SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
                .SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
                .SelectPassAndContinue()
                .VerifySection1Link3Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_HealthAndSafetyPolicy()
                .SelectPassAndContinueInHealthAndSafetyPolicyPage()
                .SelectPassAndContinue()
                .VerifySection1Link4Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassActingAsASubcontractor(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectPassAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectFailAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusFail);
        }
    }
}
