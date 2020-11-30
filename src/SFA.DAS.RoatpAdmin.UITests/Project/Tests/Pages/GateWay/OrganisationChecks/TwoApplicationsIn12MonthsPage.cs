using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class TwoApplicationsIn12MonthsPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "2 applications in 12 months check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TwoApplicationsIn12MonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
