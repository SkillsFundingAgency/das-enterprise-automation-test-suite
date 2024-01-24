using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class RegisterChecks_Section3Helpers
    {
        internal static GWApplicationOverviewPage PassRegisterChecks_ROATP(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_ROATP()
            .SelectPassAndContinue()
            .VerifyRoATP_Section3(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassRegisterChecks_RegisterOfEndPointAssessmentOrganisations(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_RegisterOfEPAO()
            .SelectPassAndContinue()
            .VerifyRegisterofendpointassessmentorganisations_Section3(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage FailRegisterChecks_RegisterOfEndPointAssessmentOrganisations(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_RegisterOfEPAO()
            .SelectFailAndContinue()
            .VerifyRegisterofendpointassessmentorganisations_Section3(StatusHelper.StatusFail);
        }
        internal static GWApplicationOverviewPage FailRegisterChecks_ROATP(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_ROATP()
            .SelectFailAndContinue()
            .VerifyRoATP_Section3(StatusHelper.StatusFail);
        }
    }
}
