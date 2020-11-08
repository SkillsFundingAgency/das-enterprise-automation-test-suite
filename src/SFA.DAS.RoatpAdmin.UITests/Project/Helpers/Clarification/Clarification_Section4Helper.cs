using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section4Helper : Moderator_Section4Helper
    {
        public override ModerationApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link1Status(StatusHelper.StatusClarification);

            return base.PassOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link2Status(StatusHelper.StatusClarification);

            return base.PassManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link3Status(StatusHelper.StatusClarification);

            return base.PassQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link4Status(StatusHelper.StatusClarification);

            return base.PassDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link5Status(StatusHelper.StatusClarification);

            return base.PassYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
        }


        public override ModerationApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link6Status(StatusHelper.StatusClarification);

            return base.PassPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
        }

        public override ModerationApplicationAssessmentOverviewPage FailQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage.VerifySection4Link3Status(StatusHelper.StatusClarification);

            return base.FailQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
        }
    }
}
