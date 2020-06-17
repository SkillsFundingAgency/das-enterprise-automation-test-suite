using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section5Helper
    {
        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section5_Link1()
            .SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
            .SelectPassAndContinue()
            .VerifySection4Link6Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section5_Link2()
            .SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
            .SelectPassAndContinue()
            .VerifySection4Link6Status(StatusHelper.StatusPass);
        }

        public ApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            return applicationAssessmentOverviewPage
            .Access_Section5_Link3()
            .SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
            .SelectPassAndContinue()
            .VerifySection4Link6Status(StatusHelper.StatusPass);
        }
    }
}
