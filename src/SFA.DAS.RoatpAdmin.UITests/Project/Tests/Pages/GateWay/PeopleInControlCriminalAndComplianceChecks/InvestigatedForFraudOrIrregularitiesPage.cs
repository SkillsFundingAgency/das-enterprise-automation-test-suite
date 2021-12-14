using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class InvestigatedForFraudOrIrregularitiesPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Investigated for fraud or irregularities in the last 3 years check";

        public InvestigatedForFraudOrIrregularitiesPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
