using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class WhatActionsHaveYouTakenPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "What actions have you taken this year to meet the target? How do these compare to the actions taken in the previous year?";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatActionsHaveYouTakenPage(ScenarioContext context) : base(context) => _context = context;

        public ReportYourProgressPage EnterActionDetails()
        {
            formCompletionHelper.EnterText(Textarea, publicSectorReportingDataHelper.EmployerActions);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}