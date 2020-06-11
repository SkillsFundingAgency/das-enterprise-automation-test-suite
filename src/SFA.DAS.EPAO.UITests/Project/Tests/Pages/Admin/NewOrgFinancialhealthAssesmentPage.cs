using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class NewOrgFinancialhealthAssesmentPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Financial health assessment";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public NewOrgFinancialhealthAssesmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationApplicationOverviewPage SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new OrganisationApplicationOverviewPage(_context);
        }
    }
}

