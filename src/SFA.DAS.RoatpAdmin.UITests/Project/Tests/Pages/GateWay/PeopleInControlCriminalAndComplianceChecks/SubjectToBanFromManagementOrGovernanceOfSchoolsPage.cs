using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks
{
    public class SubjectToBanFromManagementOrGovernanceOfSchoolsPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Subject to a ban from management or governance of schools";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubjectToBanFromManagementOrGovernanceOfSchoolsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
