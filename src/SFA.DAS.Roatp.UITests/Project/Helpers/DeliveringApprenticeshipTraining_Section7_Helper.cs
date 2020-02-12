using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class DeliveringApprenticeshipTraining_Section7_Helper
    {
        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_OverallAccountability()
                .EnterDetails()
                .VerifyOverallAccountability_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_ManagementHierarchy()
                .EnterDetails()
                .ContinueToApplicationOverview()
                .VerifyManagementHierarchy_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_QualityAndHighStandards()
                .UploadManagementExpectationsForQuality()
                .EnterTextForHowExpectationsAreMonitored()
                .EnterDetails()
                .EnterHowAreTheyCommunicatedToEmployees()
                .VerifyQualityAndHighStandards_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_5_MainProvider(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_DevelopingAndDelivering()
                .SelectYes()
                .SelectBothOptions()
                .EnterHowHasTheTeamWorked()
                .EnterDetailsOfTheManager()
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_6(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_YourSectorsAndEmployees()
                .NavigateToChooseYourOrganisationSectors()
                .SelectSectors("Digital")
                .NavigateToMostExperiencedEmployeePage("Digital")
                .EnterDetails()
                .EnterExperienceDetails()
                .SelectTypeOfApprenticeship()
                .EnterDetails()
                .ContinueToApplicationOverviewPage()
                .VerifyYourSectorsAndEmployees_Section7(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_7(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_PolicyForProfessionalDevelopment()
                .UploadOrganisationPolicyAndContinue()
                .EnterAnExampleToImproveEmployees()
                .EnterAnExampleToMaintainEmployee()
                .VerifyPolicyForProfessionalDevelopment_Section7(StatusHelper.StatusCompleted);
        }

    }
}
