using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class UnspentCriminalConvictionsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Unspent criminal convictions check";

        public UnspentCriminalConvictionsCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
