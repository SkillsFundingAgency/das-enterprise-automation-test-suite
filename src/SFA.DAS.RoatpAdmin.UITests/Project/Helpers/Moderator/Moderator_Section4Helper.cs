using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section4Helper
    {
        public virtual ModerationApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectPassAndContinueInHowExpectationsForQualityPage()
                .SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectPassAndContinue()
                .VerifySection4Link3Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectPassAndContinueInHowTheTeamWorkedWithPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
                    .SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
                    .SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_EP()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            var yourSectorsAndEmployeesPage = moderationApplicationAssessmentOverviewPage
                .Access_Section4_YourSectorsAndEmployees()
                .NavigateToDeliveringTrainingInDigitalSectorPage()
                .SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage();

            yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(yourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusPass);

            return yourSectorsAndEmployeesPage
                .NavigateToAssessmentOverviewPage()
                .VerifySection4Link5Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            var yourSectorsAndEmployeesPage = moderationApplicationAssessmentOverviewPage
                .Access_Section4_YourSectorsAndEmployees()
                .NavigateToDeliveringTrainingInDigitalSectorPage()
                .SelectFailAndContinueInDeliveringTrainingInDigitalSectorPage();

            yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(yourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusFail);

            return yourSectorsAndEmployeesPage
               .NavigateToAssessmentOverviewPage()
               .VerifySection4Link5Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
                .SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
                .SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
                .SelectPassAndContinue()
                .VerifySection4Link6Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectContinueInHowExpectationsForQualityPage()
                .SelectFailAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectContinue()
                .VerifySection4Link3Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailPolicyForProfessionalDevelopmentOfEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
                .SelectFailAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
                .SelectContinueInAnExampleOfHowThePolicyToImprovePage()
                .SelectFailAndContinue()
                .VerifySection4Link6Status(StatusHelper.StatusFail);
        }

    }
}
