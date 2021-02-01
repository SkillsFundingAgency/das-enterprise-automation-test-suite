using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class ReadOnlyGatewayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Gateway outcome";

        private By GoToRoATPGatewayApplicationsLink = By.LinkText("Go to RoATP applications");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReadOnlyGatewayOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
