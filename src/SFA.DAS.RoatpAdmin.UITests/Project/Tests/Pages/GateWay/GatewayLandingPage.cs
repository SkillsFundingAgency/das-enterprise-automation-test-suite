using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class GatewayLandingPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "New";

        //private By NewApplicationLink = By.XPath("//a[text()='INDUSTRY VETERANS LTD']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GatewayLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GWApplicationOverviewPage SelectingNewApplication()
        {
            //formCompletionHelper.ClickElement(NewApplicationLink);
            formCompletionHelper.ClickLinkByText("INDUSTRY VETERANS LTD");
            return new GWApplicationOverviewPage(_context);
        }

    }
}
