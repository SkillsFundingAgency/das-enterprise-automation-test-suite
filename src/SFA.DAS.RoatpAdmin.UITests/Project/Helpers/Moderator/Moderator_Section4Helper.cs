using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section4Helper
    {
        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link1Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link2Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link3Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link4Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link5Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link6Status(StatusHelper.StatusPass);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link3Status(StatusHelper.StatusFail);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection4Link6Status(StatusHelper.StatusFail);
            return moderationApplicationAssessmentOverviewPage;
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailOverallAccountabilityForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectFailAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailManagementHierarchyForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectFailAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusFail);
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
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectPassAndContinueInHowTheTeamWorkedWithPage()
                    .SelectPassAndContinue();
            }
            if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
                    .SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
                    .SelectPassAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
                    .SelectPassAndContinue();
            }
            else
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_EP()
                    .SelectPassAndContinue();
            }

            return moderationApplicationAssessmentOverviewPage.VerifySection4Link4Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailDevelopingAndDeliveringTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectFailAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectFailAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectFailAndContinueInHowTheTeamWorkedWithPage()
                    .SelectFailAndContinue();
            }
            else if (applicationroute == ApplicationRoute.SupportingProviderRoute)
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
                    .SelectFailAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
                    .SelectFailAndContinueInWhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage()
                    .SelectFailAndContinueInHowHasThisPersonHasWorkedWithEmployersToDevelopAndDeliverTrainingPage()
                    .SelectFailAndContinue();
            }
            else
            {
                moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectFailAndContinueInDevelopingAndDeliveringTrainingPage_EP()
                    .SelectFailAndContinue();
            }

            return moderationApplicationAssessmentOverviewPage.VerifySection4Link4Status(StatusHelper.StatusFail);
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

        public virtual ModerationApplicationAssessmentOverviewPage FailAllQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectFailAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectFailAndContinueInHowExpectationsForQualityPage()
                .SelectFailAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectFailAndContinue()
                .VerifySection4Link3Status(StatusHelper.StatusFail);
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

        public virtual ModerationApplicationAssessmentOverviewPage FailAllPolicyForProfessionalDevelopmentOfEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
                .SelectFailAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
                .SelectFailAndContinueInAnExampleOfHowThePolicyToImprovePage()
                .SelectFailAndContinue()
                .VerifySection4Link6Status(StatusHelper.StatusFail);
        }

    }
}
