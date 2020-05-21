using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.RegisterChecks
{
    public class RegisterOfEPAOCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Register of end-point assessment organisations (EPAO) check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RegisterOfEPAOCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
