using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleIncontrolChecks
{
    public class PeopleInControlHighRiskCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "People in control high risk check";

        public PeopleInControlHighRiskCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
