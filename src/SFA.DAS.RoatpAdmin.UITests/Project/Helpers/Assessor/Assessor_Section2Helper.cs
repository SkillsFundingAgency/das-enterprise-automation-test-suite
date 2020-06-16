using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section2Helper
    {
        public ApplicationAssessmentOverviewPage PassEngagingWithEmployers(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link1()
            .SelectPassAndContinueInEngagingWithEmployersPage()
            .SelectPassAndContinueInManagingRelationshipWithEmployersPage()
            .SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
            .SelectPassAndContinue()
            .VerifySection1Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassComplaintsPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link2()
            .SelectPassAndContinueInComplaintsPolicyPage()
            .SelectPassAndContinue()
            .VerifySection1Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassContractForServicesTemplate(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link3()
            .SelectPassAndContinue()
            .VerifySection1Link3Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassCommitmentStatementTemplate(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link4()
            .SelectPassAndContinue()
            .VerifySection1Link4Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassPriorLearningOfApprentices(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link5()
            .SelectPassAndContinueInPriorLearningOfApprenticesPage()
            .SelectPassAndContinue()
            .VerifySection1Link5Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassWorkingWithSubcontractors(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section2_Link6()
            .SelectPassAndContinueInWorkingWithSubcontractorsPage()
            .SelectPassAndContinue()
            .VerifySection1Link5Status(StatusHelper.StatusPass);
        }
    }
}
