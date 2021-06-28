using System;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage your apprentices";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApprenticeSearchField => By.Id("searchTerm");
        private By SearchButton => By.ClassName("das-search-form__button");
        private By SelectFilterDropdown => By.Id("selectedStatus");
        private By ApplyFilter => By.CssSelector("#main-content .govuk-button");
        private By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");
        private By NextPageLink => By.PartialLinkText("Next");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeFullName(string linkText) => By.PartialLinkText(linkText);
        private By Status => By.CssSelector("td.govuk-table__cell[data-label='Status']");
        public ManageYourApprenticesPage(ScenarioContext context): base(context) => _context = context;

        internal ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);

            var apprenticeRows = pageInteractionHelper.FindElements(ApprenticeInfoRow);
            var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName(apprenticeDataHelper.ApprenticeFullName));

            int i = 0;
            foreach (IWebElement apprenticeRow in apprenticeRows)
            {
                if (apprenticeRow.Text.Contains(apprenticeDataHelper.ApprenticeFullName))
                {
                    formCompletionHelper.ClickElement(detailsLinks);
                    return new ApprenticeDetailsPage(_context);
                }
                i++;
            }
            if (pageInteractionHelper.IsElementDisplayed(NextPageLink))
            {
                formCompletionHelper.ClickElement(NextPageLink);
            }
            else
            {
                throw new Exception("Apprentice with - " + apprenticeDataHelper.ApprenticeFullName + " - name is not found");
            }

            return new ApprenticeDetailsPage(_context);
        }

        public ManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            // Search bar will not be displayed if there are less than 10 apprentice in the table
            if (pageInteractionHelper.IsElementDisplayed(ApprenticeSearchField))
            {
                formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
                formCompletionHelper.ClickElement(SearchButton);
            }

            return new ManageYourApprenticesPage(_context);
        }

        public void VerifyApprenticeExists()
        {
            pageInteractionHelper.Verify(() =>
            {
                return pageInteractionHelper.FindElements(ViewApprenticeFullName(editedApprenticeDataHelper.ApprenticeEditedFullName)).Any();
            }, () => SearchForApprentice(editedApprenticeDataHelper.ApprenticeEditedFullName));
        }

        public ManageYourApprenticesPage Filter(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            formCompletionHelper.ClickElement(ApplyFilter);
            return new ManageYourApprenticesPage(_context);
        }

        internal ApprenticeDetailsPage SelectApprentices(string status)
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);
            tableRowHelper.SelectRowFromTable(apprenticeDataHelper.ApprenticeFullName, status);
            return new ApprenticeDetailsPage(_context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        public string GetStatus(string rowIdentifier) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(rowIdentifier, Status));
    }
}

