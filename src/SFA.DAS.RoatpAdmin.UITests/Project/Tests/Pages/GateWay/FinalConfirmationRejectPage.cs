using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class FinalConfirmationRejectPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to reject this application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinalConfirmationRejectPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public GateWayOutcomePage YesSureRejectThisApplicationAndGoToGovernance()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new GateWayOutcomePage(_context);
        }
    }
}