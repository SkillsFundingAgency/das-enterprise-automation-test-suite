using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class OrgMonitoredSupportedByOFSPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation monitored and supported by the Office of Students?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrgMonitoredSupportedByOFSPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public DescribeYourOrganisationPage SelectYesForOrgSupportedandMonitoredByOFSAndContinue()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}
