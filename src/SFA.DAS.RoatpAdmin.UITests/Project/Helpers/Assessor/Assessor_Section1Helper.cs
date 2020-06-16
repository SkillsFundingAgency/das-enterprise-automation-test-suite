using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section1Helper
    {
        public ApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section1_Link1()
            .SelectPassAndContinue()
            .VerifySection1Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section1_Link2()
            .SelectPassAndContinue()
            .VerifySection1Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section1_Link3()
            .SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
            .SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
            .SelectPassAndContinue()
            .VerifySection1Link3Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section1_Link4()
            .SelectPassAndContinueInHealthAndSafetyPolicyPage()
            .SelectPassAndContinue()
            .VerifySection1Link4Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassActingAsASubcontractor(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section1_Link5()
            .SelectPassAndContinue()
            .VerifySection1Link5Status(StatusHelper.StatusPass);
        }
    }
}
