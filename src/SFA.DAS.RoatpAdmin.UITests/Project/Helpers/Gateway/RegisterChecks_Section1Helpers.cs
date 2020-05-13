using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class RegisterChecks_Section1Helpers
    {
        internal GWApplicationOverviewPage PassRegisterChecks_ROATP(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_ROATP()
            .SelectPassAndContinue()
            .VerifyRoATP_Section3(StatusHelper_AdminPage.StatusPass);
        }

        internal GWApplicationOverviewPage PassRegisterChecks_RegisterOfEndPointAssessmentOrganisations(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section3_RegisterOfEPAO()
            .SelectPassAndContinue()
            .VerifyRegisterofendpointassessmentorganisations_Section3(StatusHelper_AdminPage.StatusPass);
        }

    }
}
