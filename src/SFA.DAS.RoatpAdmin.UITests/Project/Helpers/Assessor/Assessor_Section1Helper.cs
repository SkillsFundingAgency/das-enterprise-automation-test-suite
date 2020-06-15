using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

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
    }
}
