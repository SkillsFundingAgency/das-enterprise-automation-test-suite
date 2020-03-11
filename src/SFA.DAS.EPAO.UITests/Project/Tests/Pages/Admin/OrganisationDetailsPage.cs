using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation details";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ContactLink => By.CssSelector(".govuk-link[href*='view-contact']");

        public OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContactDetailsPage SelectContact()
        {
            formCompletionHelper.ClickLinkByText(ContactLink, "Raj PP");
            return new ContactDetailsPage(_context);
        }
    }
}
