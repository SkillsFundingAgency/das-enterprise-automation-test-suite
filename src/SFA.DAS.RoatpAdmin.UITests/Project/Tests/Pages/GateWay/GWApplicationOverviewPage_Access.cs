
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        private void NavigateToTask(string sectionName, string taskName, int index = 0) => formCompletionHelper.ClickElement(GetTaskLinkElement(sectionName, taskName, index));

        public LegalNameCheckPage Access_Section1_LegalName()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_1);
            return new LegalNameCheckPage(_context);
        }
    }
}