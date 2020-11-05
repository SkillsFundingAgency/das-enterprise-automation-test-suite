using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Clarification_Section1Helper : Moderator_Section1Helper
    {
        public new ModerationApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);
            
            return base.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public new ModerationApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);

            return base.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public new ModerationApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);

            return base.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public new ModerationApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);

            return base.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public new ModerationApplicationAssessmentOverviewPage PassActingAsASubcontractor(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);

            return base.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
        }
    }
}
