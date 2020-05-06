using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class ConfirmGatewayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subject to insolvency or winding up proceedings in the last 3 years check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmGatewayOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
