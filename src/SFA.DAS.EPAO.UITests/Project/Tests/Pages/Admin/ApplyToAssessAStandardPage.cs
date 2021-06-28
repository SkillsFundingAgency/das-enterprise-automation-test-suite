using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ApplyToAssessAStandardPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Apply to assess a standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplyToAssessAStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public StandardApplicationOverviewPage SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new StandardApplicationOverviewPage(_context);
        }
    }
}

