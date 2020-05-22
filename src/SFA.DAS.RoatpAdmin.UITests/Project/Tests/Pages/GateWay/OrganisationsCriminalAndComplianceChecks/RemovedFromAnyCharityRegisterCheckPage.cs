using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class RemovedFromAnyCharityRegisterCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Removed from any charity register check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RemovedFromAnyCharityRegisterCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
