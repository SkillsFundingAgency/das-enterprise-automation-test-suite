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

        private By ContactEmail => By.CssSelector(".govuk-table__cell[data-label='Email']");

        private By AddContactLink => By.CssSelector(".govuk-link[href*='add-contact']");

        private By StandardViewLink => By.CssSelector(".govuk-link[href*='view-standard']");

        public OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddContactPage AddNewContact()
        {
            formCompletionHelper.ClickElement(AddContactLink);
            return new AddContactPage(_context);
        }

        public ContactDetailsPage SelectContact()
        {
            VerifyPage(() => pageInteractionHelper.FindElements(ContactEmail), ePAOAdminDataHelper.Email);
            formCompletionHelper.ClickLinkByText(ePAOAdminDataHelper.FullName);
            return new ContactDetailsPage(_context);
        }

        public StandardsDetailsPage SelectStandards()
        {
            formCompletionHelper.ClickElement(() => ePAOAdminDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(StandardViewLink)));
            return new StandardsDetailsPage(_context);
        }
    }
}
