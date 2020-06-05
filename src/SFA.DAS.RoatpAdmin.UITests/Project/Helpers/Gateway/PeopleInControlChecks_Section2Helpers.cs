using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
   public class PeopleInControlChecks_Section2Helpers
    {
        internal GWApplicationOverviewPage PassPeopleInControlChecks_PeopleInControl(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControl()
            .SelectPassAndContinue()
            .VerifyPeopleincontrol_Section2(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassPeopleInControlChecks_PeopleInControlHighRisk(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section2_PeopleInControlHighRisk()
            .SelectPassAndContinue()
            .VerifyPeopleincontrolhighrisk_Section2(StatusHelper_AdminPage.StatusPass);
        }
    }
}
