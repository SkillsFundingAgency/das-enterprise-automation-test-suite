using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class RegisterChecks_Section3Helpers
    {
        internal GWApplicationOverviewPage PassRegisterChecks_ROATP(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_ROATP()
            .SelectPassAndContinue()
            .VerifyRoATP_Section3(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage PassRegisterChecks_RegisterOfEndPointAssessmentOrganisations(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_RegisterOfEPAO()
            .SelectPassAndContinue()
            .VerifyRegisterofendpointassessmentorganisations_Section3(StatusHelper.StatusPass);
        }
    }
}
