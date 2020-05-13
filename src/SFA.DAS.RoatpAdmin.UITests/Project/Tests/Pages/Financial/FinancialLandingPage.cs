using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial
{
    public class FinancialLandingPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Current applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public FinancialHealthAssessmentOverviewPage SelectingNewApplication()
        {
            //formCompletionHelper.ClickElement(NewApplicationLink);
            formCompletionHelper.ClickLinkByText("INDUSTRY VETERANS LTD");
            return new FinancialHealthAssessmentOverviewPage(_context);
        }
    }
}
