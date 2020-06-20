using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section5Helper
    {
        private readonly ScenarioContext _context;

        public Assessor_Section5Helper(ScenarioContext context) => _context = context;

        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section5_Link1()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
                .SelectPassAndContinue()
                .VerifySection5Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section5_Link2()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
                .SelectPassAndContinue()
                .VerifySection5Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section5_Link3()
                    .SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
                    .SelectPassAndContinue()
                    .VerifySection5Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection5Link3Status(StatusHelper.NotRequired);
            }
        }
    }
}
