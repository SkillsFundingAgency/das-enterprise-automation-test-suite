using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
   public class GatewayEndtoEndStepsHelpers 
   {
        internal GWApplicationOverviewPage CompleteYourOrganisation_Section1_Support(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_LegalName();

        }
    }
}
