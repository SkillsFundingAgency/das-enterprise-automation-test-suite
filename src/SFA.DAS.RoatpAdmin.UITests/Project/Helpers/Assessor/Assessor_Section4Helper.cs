using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section4Helper
    {
        private YourSectorsAndEmployeesPage _yourSectorsAndEmployeesPage;

        public ApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section4_Link1()
            .SelectPassAndContinue()
            .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section4_Link2()
            .SelectPassAndContinue()
            .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section4_Link3()
            .SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
            .SelectPassAndContinueInHowExpectationsForQualityPage()
            .SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
            .SelectPassAndContinue()
            .VerifySection4Link3Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section4_Link4()
            .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage()
            .SelectPassAndContinueInWhoTheTeamWorkedWithPage()
            .SelectPassAndContinueInHowTheTeamWorkedWithPage()
            .SelectPassAndContinue()
            .VerifySection4Link4Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            _yourSectorsAndEmployeesPage = applicationAssessmentOverviewPage
            .Access_Section4_Link5()
            .NavigateToDeliveringTrainingInDigitalSectorPage()
            .SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage();

            _yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(_yourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusPass);

            return _yourSectorsAndEmployeesPage
                .NavigateToAssessmentOverviewPage()
                .VerifySection4Link5Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section4_Link6()
            .SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
            .SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
            .SelectPassAndContinue()
            .VerifySection4Link6Status(StatusHelper.StatusPass);
        }
    }
}
