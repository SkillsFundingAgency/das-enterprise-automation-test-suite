using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class GateWayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Gateway outcome";

        private By GoToRoATPGatewayApplicationsLink => By.LinkText("Go to RoATP applications");

        public GateWayOutcomePage(ScenarioContext context) : base(context) => VerifyPage();

        public GatewayLandingPage GoToRoATPGatewayApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPGatewayApplicationsLink);
            return new GatewayLandingPage(_context);
        }
    }
}
