using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section1Helper : Moderator_Section1Helper
    {
        public override ModerationApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);

            return base.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link2Status(StatusHelper.StatusClarification);

            return base.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link3Status(StatusHelper.StatusClarification);

            return base.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link4Status(StatusHelper.StatusClarification);

            return base.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassActingAsASubcontractor(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link5Status(StatusHelper.StatusClarification);

            return base.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage FailSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection1Link3Status(StatusHelper.StatusClarification);

            return base.FailSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
        }
    }
}
