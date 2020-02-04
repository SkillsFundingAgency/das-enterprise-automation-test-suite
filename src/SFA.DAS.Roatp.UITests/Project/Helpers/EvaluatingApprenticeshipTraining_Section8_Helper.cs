using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class EvaluatingApprenticeshipTraining_Section8_Helper
    {
        internal ApplicationOverviewPage CompleteEvaluatingApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section8_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section8(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteEvaluatingApprenticeshipTraining_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section8_ProcessForEvaluatingTheQualityOfTrainingDelivered()
                .EnterTextRegardingOrganisationProcessForEvaluatingTheQualityOfTrainingDeliveredAndContinue()
                .EnterTextRegardingOrganisationImprovementsUsingEvaluatingTheQualityOfTrainingAndContinue()
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteEvaluatingApprenticeshipTraining_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section8_ProcessForEvaluatingTheQualityOfApprenticeshipTraining()
                .yesAndContinue()
                .EnterTextRegardingOrganisationReviewAndContinue()
                .VerifyQualityOfTheTraining_Section8(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteEvaluatingApprenticeshipTraining_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section8_SystemsAndProcessesToCollectApprenticeshipDataForMainAndEmpoyerRoute()
                .SelectYesAndContinueOnCollectingDataPage()
                .SelectYesAndContinueonILRpage()
                .VerifySystemsAndProcesses_Section8(StatusHelper.StatusCompleted);
        }
    }
}
