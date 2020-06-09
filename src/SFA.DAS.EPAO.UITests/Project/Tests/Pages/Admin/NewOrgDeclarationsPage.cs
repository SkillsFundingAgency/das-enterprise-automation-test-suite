using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class NewOrgDeclarationsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Declarations";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public NewOrgDeclarationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}

