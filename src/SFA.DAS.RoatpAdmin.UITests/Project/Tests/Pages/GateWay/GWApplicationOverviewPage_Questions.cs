using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
       
        private string OrganisationChecks => "1. Organisation checks";
        private string OrganisationChecks_1 => "Legal name";
    }
}