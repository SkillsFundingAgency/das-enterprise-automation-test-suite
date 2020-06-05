using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks
{
    public class SubcontractorDeclarationCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subcontractor declaration check";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubcontractorDeclarationCheckPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
