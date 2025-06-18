using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class DeliveringApprenticeshipTraining_Section7_Helper
    {
        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_OverallAccountability()
                .EnterDetails()
                .VerifyOverallAccountability_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_ManagementHierarchy()
                .EnterDetails()
                .ContinueToApplicationOverview()
                .VerifyManagementHierarchy_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_QualityAndHighStandards()
                .UploadManagementExpectationsForQuality()
                .EnterTextForHowExpectationsAreMonitored()
                .EnterDetails()
                .EnterHowAreTheyCommunicatedToEmployees()
                .VerifyQualityAndHighStandards_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_5_MainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_DevelopingAndDelivering()
                .SelectYes()
                .SelectOrganisations()
                .EnterHowHasTheTeamOrPersonWorked()
                .EnterDetailsOfTheManager()
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_5_EmployerRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_DevelopingAndDelivering()
                .SelectNo()
                .SelectNo()
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_5_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_DevelopingAndDelivering_Support()
                .SelectYes()
                .SelectEmployersOptions()
                .EnterHowHasTheTeamOrPersonWorked()
                .EnterDetailsOfTheManagerPerson()
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.StatusCompleted);
        }
        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_6_NotRequired(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {

                return applicationOverviewPage.Access_Section7_YourSectorsAndEmployees()
                    .NavigateToChooseYourOrganisationSectors()
                    .SelectSectors("Digital")
                    .NavigateToMostExperiencedEmployeePage("Digital")
                    .EnterTextForWhatStandardsToDeliver()
                    .EnterNumberOfStartsAndContinue()
                    .EnterNumberOfEmployeesAndContinue()
                    .EnterDetails()
                    .EnterExperienceDetails()
                    .SelectTypeOfApprenticeship()
                    .EnterDetails()
                    .ContinueToApplicationOverviewPage()
                    .VerifyYourSectorsAndEmployees_Section7(StatusHelper.StatusCompleted);
            }
            else
            {
                return applicationOverviewPage.VerifyYourSectorsAndEmployees_Section7(StatusHelper.NotRequired);
            }
        }
        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_6(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_YourSectorsAndEmployees()
                .NavigateToChooseYourOrganisationSectors()
                .SelectSectors("Digital")
                .NavigateToMostExperiencedEmployeePage("Digital")
                .EnterTextForWhatStandardsToDeliver()
                .EnterNumberOfStartsAndContinue()
                .EnterNumberOfEmployeesAndContinue()
                .EnterDetails()
                .EnterExperienceDetails()
                .SelectTypeOfApprenticeship()
                .EnterDetails()
                .ContinueToApplicationOverviewPage()
                .VerifyYourSectorsAndEmployees_Section7(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_7(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_PolicyForProfessionalDevelopment()
                .UploadOrganisationPolicyAndContinue()
                .EnterAnExampleToImproveEmployees()
                .EnterAnExampleToMaintainEmployee()
                .VerifyPolicyForProfessionalDevelopment_Section7(StatusHelper.StatusCompleted);
        }
    }
}
