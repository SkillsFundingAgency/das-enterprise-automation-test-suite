using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class BreachedTaxPaymentsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Breached tax payments or social security contributions in the last 3 years check";

        public BreachedTaxPaymentsCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
