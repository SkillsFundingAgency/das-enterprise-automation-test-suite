using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section5Helper
    {
        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection5Link1Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection5Link2Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection5Link3Status(StatusHelper.StatusPass);
            return moderationApplicationAssessmentOverviewPage;
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
                .SelectPassAndContinue()
                .VerifySection5Link1Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
                .SelectPassAndContinue()
                .VerifySection5Link2Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
                    .SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
                    .SelectPassAndContinueForILRDataPage()
                    .SelectPassAndContinue()
                    .VerifySection5Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection5Link3Status(StatusHelper.NotRequired);
            }
        }
        public virtual ModerationApplicationAssessmentOverviewPage FailProcessForEvaluatingTheQualityOfTrainingDelivered(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
                .SelectFailAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
                .SelectFailAndContinue()
                .VerifySection5Link1Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailProcessForEvaluatingTheQualityOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
                .SelectFailAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
                .SelectFailAndContinue()
                .VerifySection5Link2Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailSystemsAndProcessesToCollectApprenticeshipData(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
                    .SelectFailAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
                    .SelectFailAndContinue()
                    .VerifySection5Link3Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection5Link3Status(StatusHelper.NotRequired);
            }
        }
    }
}
