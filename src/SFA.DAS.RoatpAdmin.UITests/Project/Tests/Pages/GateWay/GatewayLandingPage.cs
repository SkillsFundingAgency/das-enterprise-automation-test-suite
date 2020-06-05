using SFA.DAS.Roatp.UITests.Project;
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
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new GWApplicationOverviewPage(_context);
        }
    }
}
