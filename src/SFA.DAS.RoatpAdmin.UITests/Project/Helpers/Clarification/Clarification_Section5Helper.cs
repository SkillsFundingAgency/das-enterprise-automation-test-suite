using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section5Helper : Moderator_Section5Helper
    {
        public override ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection5Link1Status(StatusHelper.StatusClarification);

            return base.PassProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection5Link2Status(StatusHelper.StatusClarification);

            return base.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection5Link3Status(StatusHelper.StatusClarification);

            return base.PassSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage, applicationroute);
        }
    }
}
