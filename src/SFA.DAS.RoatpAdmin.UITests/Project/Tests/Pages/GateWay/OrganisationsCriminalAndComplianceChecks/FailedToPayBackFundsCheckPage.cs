using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class FailedToPayBackFundsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Failed to pay back funds in the last 3 years check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FailedToPayBackFundsCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
