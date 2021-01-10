using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightLandingPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "RoATP application outcomes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OversightLandingPage(ScenarioContext context) : base(context) => _context = context;
    }
}
