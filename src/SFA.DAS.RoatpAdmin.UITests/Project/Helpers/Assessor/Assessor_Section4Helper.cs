using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section4Helper
    {
        public static ApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public static ApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectPassAndContinueInManagementHierarchyPage()
                .SelectPassAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public static ApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectPassAndContinueInHowExpectationsForQualityPage()
                .SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectPassAndContinue()
                .VerifySection4Link3Status(StatusHelper.StatusPass);
        }

        public static ApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute ||
                applicationroute == ApplicationRoute.MainProviderRouteForExistingProvider)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectPassAndContinueInHowTheTeamWorkedWithPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute ||
                 applicationroute == ApplicationRoute.SupportingProviderRouteForExistingProvider)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
                    .SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
                    .SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_EP()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
        }

        public static ApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.SupportingProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider ||
                applicationroute == ApplicationRoute.SupportingProviderRouteForExistingProvider)
            {
                return applicationAssessmentOverviewPage
                    .VerifySection4Link5Status(StatusHelper.NotRequired);
            }
            else
            {
                var yourSectorsAndEmployeesPage = applicationAssessmentOverviewPage
                .Access_Section4_YourSectorsAndEmployees()
                .NavigateToDeliveringTrainingInDigitalSectorPage()
                .SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage();

                yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(YourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusPass);

                return yourSectorsAndEmployeesPage
                    .NavigateToAssessmentOverviewPage()
                    .VerifySection4Link5Status(StatusHelper.StatusPass);
            }
        }

        public static ApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
                .SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
                .SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
                .SelectPassAndContinue()
                .VerifySection4Link6Status(StatusHelper.StatusPass);
        }
    }
}
