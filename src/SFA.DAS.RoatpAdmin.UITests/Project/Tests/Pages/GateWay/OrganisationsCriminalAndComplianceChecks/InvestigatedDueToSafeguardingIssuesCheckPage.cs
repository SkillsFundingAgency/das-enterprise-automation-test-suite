using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class InvestigatedDuetoSafeguardingIssuesCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Investigated due to safeguarding issues in the last 3 months check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvestigatedDuetoSafeguardingIssuesCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
