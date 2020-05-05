using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class TradingNameCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TradingNameCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
