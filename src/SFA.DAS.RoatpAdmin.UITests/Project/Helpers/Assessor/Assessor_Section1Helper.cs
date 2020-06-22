using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section1Helper
    {
        private readonly ScenarioContext _context;

        public Assessor_Section1Helper(ScenarioContext context) => _context = context;

        public ApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section1_Link1()
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
