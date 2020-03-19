using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class EditOrganisationPage : AddOrEditOrganisationPage
    {
        protected override string PageTitle => "Edit organisation";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MakeLiveButton => By.CssSelector(".govuk-button[value='MakeLive']");

        public EditOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationDetailsPage MakeOrgLive()
        {
            formCompletionHelper.ClickElement(MakeLiveButton);
            return new OrganisationDetailsPage(_context);
        }

        public OrganisationDetailsPage EditDetails()
        {
            formCompletionHelper.EnterText(CompanyNumberField, ePAOAdminDataHelper.CompanyNumber);
            formCompletionHelper.EnterText(CharityNumberField, ePAOAdminDataHelper.CharityNumber);
            Continue();
            return new OrganisationDetailsPage(_context);
        }

    }
}
