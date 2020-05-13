using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
   public class PeopleInControlCriminalAndComplianceChecks_Section1Helpers
    {
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_CompositionWithCreditors(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_CompositionWithCreditors()
            .SelectPassAndContinue()
            .VerifyCompositionwithcreditors_Section5(StatusHelper_AdminPage.StatusPass);
        }

    }
}
