using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class InvestigatedByESFAorOtherPublicBodyPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Investigated by the ESFA or other public body or regulator check";

        public InvestigatedByESFAorOtherPublicBodyPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
