using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class WhatChallengesHaveYouFacedPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "What challenges have you faced this year in your efforts to meet the target? How do these compare to the challenges experienced in the previous year?";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatChallengesHaveYouFacedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterChallengesDetails()
        {
            formCompletionHelper.EnterText(Textarea, dataHelper.EmployerChallenges);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}