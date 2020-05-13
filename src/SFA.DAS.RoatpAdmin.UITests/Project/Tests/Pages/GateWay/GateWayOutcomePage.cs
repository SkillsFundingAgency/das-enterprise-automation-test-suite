using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class GateWayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Gateway outcome saved";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GateWayOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
