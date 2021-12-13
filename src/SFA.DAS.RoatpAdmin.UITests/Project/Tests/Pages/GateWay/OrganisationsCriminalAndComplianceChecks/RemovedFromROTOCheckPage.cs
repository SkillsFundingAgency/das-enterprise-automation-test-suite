using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class RemovedFromROTOCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Removed from Register of Training Organisations (RoTO) in the last 3 years check";

        public RemovedFromROTOCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
