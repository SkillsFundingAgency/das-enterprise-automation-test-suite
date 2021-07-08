using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section3Helper
    {
        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection3Link1Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection3Link4Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection3Link5Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection3Link6Status(StatusHelper.StatusPass);

            if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            return moderationApplicationAssessmentOverviewPage;
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            var typeOfApprenticeshipTrainingPage = moderatorApplicationAssessmentOverviewPage.Access_Section3_TypeOfApprenticeshipTraining();

            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectPassAndContinueInDeliveringTraining()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage_IncludesFrameworks()
                    .SelectPassAndContinue();

            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinue();
            }
            else
            {
                moderatorApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameWorksOnly()
                    .SelectPassAndContinue();
            }

            return moderatorApplicationAssessmentOverviewPage.VerifySection3Link1Status(StatusHelper.StatusPass);

        }

        public virtual ModerationApplicationAssessmentOverviewPage FailTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            var typeOfApprenticeshipTrainingPage = moderationApplicationAssessmentOverviewPage.Access_Section3_TypeOfApprenticeshipTraining();

            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectPassAndContinueInDeliveringTraining()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage_IncludesFrameworks()
                    .SelectPassAndContinue();
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectFailAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectFailAndContinue();
            }
            else
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectFailAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectFailAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameWorksOnly()
                    .SelectFailAndContinue();
            }

            return moderationApplicationAssessmentOverviewPage.VerifySection3Link1Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailAllTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            var typeOfApprenticeshipTrainingPage = moderationApplicationAssessmentOverviewPage.Access_Section3_TypeOfApprenticeshipTraining();

            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectFailAndContinueInDeliveringTraining()
                    .SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectFailAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage_DeliveryIncludesFrameworks()
                    .SelectFailAndContinue();
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectFailAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectFailAndContinue();
            }
            else
            {
                moderationApplicationAssessmentOverviewPage = typeOfApprenticeshipTrainingPage
                    .SelectFailAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectFailAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectFailAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameworksOnly()
                    .SelectFailAndContinue();
            }

            return moderationApplicationAssessmentOverviewPage.VerifySection3Link1Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassTrainingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_TrainingApprentices()
                    .SelectPassAndContinue()
                    .VerifySection3Link2Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailTrainingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_TrainingApprentices()
                    .SelectFailAndContinue()
                    .VerifySection3Link2Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassSupportingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage()
                    .SelectPassAndContinueInWaysOfSupportingApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.VerifySection3Link3Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailSupportingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectFailAndContinueInSupportingApprenticesPage()
                    .SelectFailAndContinueInWaysOfSupportingApprenticesPage()
                    .SelectFailAndContinue()
                    .VerifySection3Link3Status(StatusHelper.StatusFail);
            }
            else if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectFailAndContinueInSupportingApprenticesPage_MainRoute()
                    .VerifySection3Link3Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.VerifySection3Link3Status(StatusHelper.NotRequired);
            }
        }


        public virtual ModerationApplicationAssessmentOverviewPage PassForecastingStarts(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || 
                applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return moderatorApplicationAssessmentOverviewPage
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
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection3Link4Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailForecastingStarts(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_ForecastingStarts()
                    .SelectFailAndContinueInForecastingStartsPage()
                    .SelectFailAndContinueInReadyToDeliverTrainingAgainstForecastPage()
                    .SelectFailAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
                    .SelectFailAndContinueInTypicalRatioOfStaffDeliveringTraining()
                    .SelectFailAndContinue()
                    .VerifySection3Link4Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection3Link4Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassOffTheJobTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_OffTheJobTraining()
                    .SelectPassAndContinueInOffTheJobTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link5Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailOffTheJobTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_OffTheJobTraining()
                    .SelectFailAndContinueInOffTheJobTrainingPage()
                    .SelectFailAndContinue()
                    .VerifySection3Link5Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link5Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassWhereWillYourApprenticesBeTrained(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || 
                applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return moderatorApplicationAssessmentOverviewPage
                .Access_Section3_WhereWillYourApprenticesBeTrained()
                .SelectPassAndContinue()
                .VerifySection3Link6Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link6Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailWhereWillYourApprenticesBeTrained(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                .Access_Section3_WhereWillYourApprenticesBeTrained()
                .SelectFailAndContinue()
                .VerifySection3Link6Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link6Status(StatusHelper.NotRequired);
            }
        }
    }
}
