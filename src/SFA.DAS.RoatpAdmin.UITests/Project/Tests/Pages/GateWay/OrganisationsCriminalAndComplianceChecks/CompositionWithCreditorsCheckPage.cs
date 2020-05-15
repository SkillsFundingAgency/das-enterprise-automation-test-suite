using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks
{
    public class CompositionWithCreditorsCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Composition with creditors check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CompositionWithCreditorsCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
