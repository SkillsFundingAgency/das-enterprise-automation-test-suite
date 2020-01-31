using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ProtectingYourApprentices_Section4_Helper
    {
        internal ApplicationOverviewPage CompleteProtectingYourApprentices_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section4_IntroductionWhatYouWillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section4(StatusHelper.StatusCompleted);
                
        }
        internal ApplicationOverviewPage CompleteProtectingYourApprentices_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section4_ContinuityPlanForApprenticeshipTraining()
                .ContinuityPlanFileUploadAndContinue()
                .VerifyContinuity_Section4(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteProtectingYourApprentices_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section4_EqualityAndDiversityPolicy()
                .EqualityAndDiversityPolicyFileUploadAndContinue()
                .VerifyEquality_Section4(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteProtectingYourApprentices_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section4_SafeguardingPolicy()
                    .SafeguardingPolicyFileUploadAndContinue()
                    .EnterDetailsOfSafeguardingPerson()
                    .SelectYesForPreventDutyPageAndContinue()
                    .VerifySafeguarding_Section4(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteProtectingYourApprentices_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section4_HealthAndSafetyPolicy()
                .HealthAndSafetyPolicyFileUploadAndContinue()
                .EnterDetailsOfHealthAndSafetyPerson()
                .VerifyHealthAndSafety_Section4(StatusHelper.StatusCompleted);
        }

    }
}
