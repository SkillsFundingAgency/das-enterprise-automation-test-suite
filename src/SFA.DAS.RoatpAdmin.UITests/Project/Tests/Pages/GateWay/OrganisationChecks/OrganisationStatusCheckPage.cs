using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class OrganisationStatusCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Organisation status check";

        public OrganisationStatusCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
