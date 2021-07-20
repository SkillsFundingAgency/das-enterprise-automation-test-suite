using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section5Helper
    {
        public Assessor_Section5Helper() { }

        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
                .SelectPassAndContinue()
                .VerifySection5Link1Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
                .Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
                .SelectPassAndContinue()
                .VerifySection5Link2Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRoute ||
                applicationroute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
            {
                return applicationAssessmentOverviewPage
                    .Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
                    .SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
                    .SelectPassAndContinueForILRDataPage()
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
