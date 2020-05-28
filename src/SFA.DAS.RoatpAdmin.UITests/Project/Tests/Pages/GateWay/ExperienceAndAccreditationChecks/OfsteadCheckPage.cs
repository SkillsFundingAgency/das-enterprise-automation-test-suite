using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks
{
    public class OfsteadCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Ofsted check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OfsteadCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
