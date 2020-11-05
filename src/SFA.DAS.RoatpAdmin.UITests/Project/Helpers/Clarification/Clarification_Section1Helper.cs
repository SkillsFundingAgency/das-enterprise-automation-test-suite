using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Clarification_Section1Helper : Moderator_Section1Helper
    {
        public new ModerationApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusClarification);
            
            return base.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }
    }
}
