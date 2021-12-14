using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks
{
    public class WebsiteAddressCheckPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Website address check";

        public WebsiteAddressCheckPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
