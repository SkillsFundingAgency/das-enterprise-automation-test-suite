using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section3Helper
    {
        public ApplicationAssessmentOverviewPage PassTypeOfApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
        }

        public ApplicationAssessmentOverviewPage PassTrainingApprentices(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TrainingApprentices()
                    .SelectPassAndContinue()
                    .VerifySection3Link2Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassSupportingApprentices(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage()
                    .SelectPassAndContinueInWaysOfSupportingApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.VerifySection3Link3Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassForecastingStarts(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_ForecastingStarts()
                    .SelectPassAndContinueInForecastingStartsPage()
                    .SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinueInTypicalRatioOfStaffDeliveringTraining()
                    .SelectPassAndContinue()
                    .VerifySection3Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection3Link4Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassOffTheJobTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_OffTheJobTraining()
                    .SelectPassAndContinueInOffTheJobTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.
                    VerifySection3Link5Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassWhereWillYourApprenticesBeTrained(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                .Access_Section3_WhereWillYourApprenticesBeTrained()
                .SelectPassAndContinue()
                .VerifySection3Link6Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.
                    VerifySection3Link6Status(StatusHelper.NotRequired);
            }
        }
    }
}
