using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation details";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        private By EditOrganisationLink => By.CssSelector("[href*='edit-organisation']");

        private By ContactEmail => By.CssSelector(".govuk-table__cell[data-label='Email']");

        private By AddContactLink => By.CssSelector(".govuk-link[href*='add-contact']");

        private By AddStandardLink => By.CssSelector(".govuk-link[href*='search-standards']");

        private By StandardPagination => By.CssSelector("#PaginationViewModel_ItemsPerPage");

        public OrganisationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public EditOrganisationPage EditOrganisation()
        {
            formCompletionHelper.ClickElement(EditOrganisationLink);
            return new EditOrganisationPage(_context);
        }

        public OrganisationDetailsPage VerifyOrganisationStatus(string status) => VerifyOrganisationDetails("Organisation status", status);
        
        public OrganisationDetailsPage VerifyOrganisationCharityNumber() => VerifyOrganisationDetails("Charity number", ePAOAdminDataHelper.CharityNumber);
        
        public OrganisationDetailsPage VerifyOrganisationCompanyNumber() => VerifyOrganisationDetails("Company number", ePAOAdminDataHelper.CompanyNumber);

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
        
        private OrganisationDetailsPage VerifyOrganisationDetails(string headerName, string value)
        {
            pageInteractionHelper.VerifyText(GetData(headerName).Text, value);
            return new OrganisationDetailsPage(_context);
        }
    }
}
