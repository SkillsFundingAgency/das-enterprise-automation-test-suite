using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class PlanningApprenticeshipTraining_Section6_Helper
    {
        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section6(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_TypeOfApprenticeshipTraining()
                .SelectStandardsFrameworksAndContinue()
                .EnterTextRegardingReadyToDeliverTrainingAndContinue()
                .EnterTextRegardingEngageWithEPAOandContinue()
                .EnterTextForEngageAndWorkWithAwardingBodiesMainRouteAndContinue()
                .EnterContactDetailsAndContinue()
                .VerifyTypeOfTrainning_Section6(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_ForeCastingStarts()
                .SelectOneTo49ForecastAndContinue()
                .SelectWithinTheFirstThreeMonthAndContinue()
                .SelectYesRecruitNewStaffAndContinue()
                .SelectOneTrainerBetween10OrLessApprenticesAndContinue()
                .VerifyForecasting_Section6(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_OffTheJobTraining()
                .SelectLearningSupportAndWrritenAssignmentsAndContinue()
                .EnterTextForOffTheJobTrainingIsRelevantAndContinue()
                .VerifyOffTheJobTrainning_Section6(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompletePlanningApprenticeshipTraining_6(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section6_WhereWillYourApprenticesBeTrained()
                .EnterTrainingLocationDetailsAndContinue()
                .VerifyWhereWillYourApprenticesBeTrained_Section6(StatusHelper.StatusCompleted);
        }
    }
}
