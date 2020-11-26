using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section1Helper
    {

        public ApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section1_ContinuityPlanForApprenticeshipTraining()
                    .SelectPassAndContinue()
                    .VerifySection1Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection1Link1Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section1_EqualityAndDiversityPolicy()
                .SelectPassAndContinue()
                .VerifySection1Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section1_SafeguardingAndPreventDutyPolicy()
                .SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
                .SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
                .SelectPassAndContinue()
                .VerifySection1Link3Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section1_HealthAndSafetyPolicy()
                .SelectPassAndContinueInHealthAndSafetyPolicyPage()
                .SelectPassAndContinue()
                .VerifySection1Link4Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassActingAsASubcontractor(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectPassAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusPass);
        }
    }
}
