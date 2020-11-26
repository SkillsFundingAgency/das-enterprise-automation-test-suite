using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section4Helper
    {
        public ApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectPassAndContinueInHowExpectationsForQualityPage()
                .SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectPassAndContinue()
                .VerifySection4Link3Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectPassAndContinueInHowTheTeamWorkedWithPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
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

        public ApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            var yourSectorsAndEmployeesPage = applicationAssessmentOverviewPage
                .Access_Section4_YourSectorsAndEmployees()
                .NavigateToDeliveringTrainingInDigitalSectorPage()
                .SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage();

            yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(yourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusPass);

            return yourSectorsAndEmployeesPage
                .NavigateToAssessmentOverviewPage()
                .VerifySection4Link5Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
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
