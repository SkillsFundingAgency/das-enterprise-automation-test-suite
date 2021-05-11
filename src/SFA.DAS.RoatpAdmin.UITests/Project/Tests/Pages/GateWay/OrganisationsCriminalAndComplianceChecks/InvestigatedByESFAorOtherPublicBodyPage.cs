using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class InvestigatedByESFAorOtherPublicBodyPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Investigated by the ESFA or other public body or regulator check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvestigatedByESFAorOtherPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
