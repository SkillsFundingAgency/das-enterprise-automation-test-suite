using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section4Helper
    {
        private readonly ScenarioContext _context;
        private YourSectorsAndEmployeesPage _yourSectorsAndEmployeesPage;

        public Moderator_Section4Helper(ScenarioContext context) => _context = context;

        public ModerationApplicationAssessmentOverviewPage PassOverallAccountabilityForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_OverallAccountabilityForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link1Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassManagementHierarchyForApprenticeships(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_ManagementHierarchyForApprenticeships()
                .SelectPassAndContinue()
                .VerifySection4Link2Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassQualityAndHighStandardsInApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
                .SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
                .SelectPassAndContinueInHowExpectationsForQualityPage()
                .SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
                .SelectPassAndContinue()
                .VerifySection4Link3Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassDevelopingAndDeliveringTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01"))
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
                    .SelectPassAndContinueInDevelopingAndDeliveringTrainingPage_MP()
                    .SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
                    .SelectPassAndContinueInHowTheTeamWorkedWithPage()
                    .SelectPassAndContinue()
                    .VerifySection4Link4Status(StatusHelper.StatusPass);
            }
            else if (_context.ScenarioInfo.Tags.Contains("rpadmod02"))
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

        public ModerationApplicationAssessmentOverviewPage PassYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            _yourSectorsAndEmployeesPage = moderationApplicationAssessmentOverviewPage
                .Access_Section4_YourSectorsAndEmployees()
                .NavigateToDeliveringTrainingInDigitalSectorPage()
                .SelectPassAndContinueInDeliveringTrainingInDigitalSectorPage();

            _yourSectorsAndEmployeesPage.VerifyStatusBesideGenericQuestion(_yourSectorsAndEmployeesPage.DigitalLinkText, StatusHelper.StatusPass);

            return _yourSectorsAndEmployeesPage
                .NavigateToAssessmentOverviewPage()
                .VerifySection4Link5Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassPolicyForProfessionalDevelopmentOfEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
                .SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
                .SelectPassAndContinueInAnExampleOfHowThePolicyToImprovePage()
                .SelectPassAndContinue()
                .VerifySection4Link6Status(StatusHelper.StatusPass);
        }
    }
}
