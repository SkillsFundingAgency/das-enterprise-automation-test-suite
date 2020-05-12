using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {

        public GWApplicationOverviewPage VerifyOrganisationChecks_Section1(string status) => Verify_Section1(OrganisationChecks_1, status);

        private GWApplicationOverviewPage Verify_Section1(string taskName, string status) => VerifySections(OrganisationChecks, taskName, status);

        private GWApplicationOverviewPage VerifySections(string sectionName, string taskName, string status, int index = 0)
        {
            VerifyElement(GetTaskStatusElement(sectionName, taskName, index), status, (null));
            return new GWApplicationOverviewPage(_context);
        }
    }
}