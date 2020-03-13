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

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ContactEmail => By.CssSelector(".govuk-table__cell[data-label='Email']");

        private By AddContactLink => By.CssSelector(".govuk-link[href*='add-contact']");

        private By AddStandardLink => By.CssSelector(".govuk-link[href*='search-standards']");

        private By StandardPagination => By.CssSelector("#PaginationViewModel_ItemsPerPage");

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

        public AddStandardPage AddAStandard()
        {
            formCompletionHelper.ClickElement(AddStandardLink);
            return new AddStandardPage(_context);
        }

        public ContactDetailsPage SelectContact()
        {
            VerifyPage(() => pageInteractionHelper.FindElements(ContactEmail), ePAOAdminDataHelper.Email);
            formCompletionHelper.ClickLinkByText(ePAOAdminDataHelper.FullName);
            return new ContactDetailsPage(_context);
        }

        public StandardsDetailsPage SelectStandards()
        {
            var pageoptions = pageInteractionHelper.GetAvailableOptions(StandardPagination);
            var maxoption = pageoptions.Select(x => int.Parse(x)).Max();
            formCompletionHelper.SelectFromDropDownByValue(StandardPagination, maxoption.ToString());
            pageInteractionHelper.WaitforURLToChange("itemsPerPage=500");
            tableRowHelper.SelectRowFromTable("View", ePAOAdminDataHelper.StandardsName, "#approved table");
            return new StandardsDetailsPage(_context);
        }
    }
}
