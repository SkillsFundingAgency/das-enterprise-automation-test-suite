using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class PlanningApprenticeshipTraining_Section6_Helper
    {
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_TrainingApprentices()
               .SelectInYourOrganisationAndContinue()
                .VerifyTrainingApprentices_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_TypeOfApprenticeshipTraining()
                .SelectStandardsFrameworksAndContinue()
                .EnterTextRegardingReadyToDeliverTrainingAndContinue()
                .EnterTextRegardingEngageWithEPAOandContinue()
                .EnterTextForTransitionFromFramewordsToStandardsAndContinueIncludesFrameworks()
                .EnterTextForEngageAndWorkWithAwardingBodies()
                .VerifyTypeOfTrainning_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_2_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section6_TypeOfApprenticeshipTraining()
                .SelectFrameworksOnlyAndContinue()
                .SelectYesForTransitionFromFrameworksToStandardsAndContinue()
                .EnterTextForTransitionFromFramewordsToStandardsAndContinueEmployerRoute()
                .EnterTextRegardingEngageWithEPAOandContinue_FrameworksOnly()
                .EnterTextForEngageAndWorkWithAwardingBodies()
                .VerifyTypeOfTrainning_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_2_Support(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section6_TypeOfApprenticeshipTraining()
                .SelectFrameworksOnlyAndContinue()
                .SelectYesForTransitionFromFrameworksToStandardsAndContinue()
                .EnterTextForTransitionFromFramewordsToStandardsAndContinueSupportingRoute()
                .VerifyTypeOfTrainning_Section6(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_SupportingApprentices()
                .EnterTextForHowOrgEnsureApprenticesAreSupportedAndContinue()
                .SelectThroughAMentorAndOTherAndContinue()
                .EnterTextForOtherWaysToSupportApprenticesAndContinue()
                .VerifySupporting_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_4_MainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_SupportingApprentices()
                .EnterTextForHowOrgEnsureApprenticesAreSupportedAndContinue_MainRoute()
                .VerifySupporting_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_ForeCastingStarts()
                .SelectOneTo49ForecastAndContinue()
                .SelectWithinTheFirstThreeMonthAndContinue()
                .SelectYesRecruitNewStaffAndContinue()
                .SelectOneTrainerBetween10OrLessApprenticesAndContinue()
                .EnterTextRegardingHowDoYouAgreeForSupportProvidedAndContinue()
                .VerifyForecasting_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_6(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_OffTheJobTraining()
                .SelectLearningSupportAndWrritenAssignmentsAndContinue()
                .EnterTextForOffTheJobTrainingIsRelevantAndContinue()
                .VerifyOffTheJobTrainning_Section6(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_7(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_WhereWillYourApprenticesBeTrained()
                .EnterTrainingLocationDetailsAndContinue()
                .VerifyWhereWillYourApprenticesBeTrained_Section6(StatusHelper.StatusCompleted);
        }
    }
}
