using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class TeachingRegulationAgencyPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subject to a prohibition order from the Teaching Regulation Agency";

        public TeachingRegulationAgencyPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
