using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class BreachedTaxPaymentsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Breached tax payments or social security contributions in the last 3 years check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public BreachedTaxPaymentsCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
