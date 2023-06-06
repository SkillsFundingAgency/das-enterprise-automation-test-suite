using System;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class FilteredManageYourApprenticesPage : ManageYourApprenticesPage
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override bool TakeFullScreenShot => true;

        public FilteredManageYourApprenticesPage(ScenarioContext context) : base(context) { }

    }

    public class ManageYourApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override bool TakeFullScreenShot => false;

        private static By ApprenticeSearchField => By.Id("searchTerm");
        private static By SearchButton => By.ClassName("das-search-form__button");
        private static By SelectFilterDropdown => By.Id("selectedStatus");
        private static By ApplyFilter => By.CssSelector("#main-content .govuk-button");
        private static By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");
        private static By NextPageLink => By.PartialLinkText("Next");
        private static By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private static By ViewApprenticeFullName(string linkText) => By.PartialLinkText(linkText);
        private static By Status => By.CssSelector("td.govuk-table__cell[data-label='Status']");
        public ManageYourApprenticesPage(ScenarioContext context): base(context)  { }

        internal ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            VerifyApprenticeExists(apprenticeDataHelper.ApprenticeFullName);

            var apprenticeRows = pageInteractionHelper.FindElements(ApprenticeInfoRow);
            var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName(apprenticeDataHelper.ApprenticeFullName));

            int i = 0;
            foreach (IWebElement apprenticeRow in apprenticeRows)
            {
                if (apprenticeRow.Text.Contains(apprenticeDataHelper.ApprenticeFullName))
                {
                    formCompletionHelper.ClickElement(detailsLinks);
                    return new ApprenticeDetailsPage(context);
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

            return new ApprenticeDetailsPage(context);
        }

        public FilteredManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            // Search bar will not be displayed if there are less than 10 apprentice in the table
            if (pageInteractionHelper.IsElementDisplayed(ApprenticeSearchField))
            {
                formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
                formCompletionHelper.ClickElement(SearchButton);
            }

            return new FilteredManageYourApprenticesPage(context);
        }

        public ApprenticeDetailsPage SelectFromRow(string apprenticesFirstName, string status)
        {
            tableRowHelper.SelectRowFromTable(apprenticesFirstName, status);
            return new ApprenticeDetailsPage(context);
        }

        public void VerifyApprenticeExists() => VerifyApprenticeExists(editedApprenticeDataHelper.ApprenticeEditedFullName);

        public ManageYourApprenticesPage Filter(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            formCompletionHelper.ClickElement(ApplyFilter);
            return new ManageYourApprenticesPage(context);
        }

        internal ApprenticeDetailsPage SelectApprentices(string status)
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);
            tableRowHelper.SelectRowFromTable(apprenticeDataHelper.ApprenticeFullName, status);
            return new ApprenticeDetailsPage(context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        public string GetStatus(string rowIdentifier) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(rowIdentifier, Status));

        private void VerifyApprenticeExists(string name)
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                SearchForApprentice(name);

                pageInteractionHelper.FindElement(ViewApprenticeFullName(name));
            });
        }
    }
}

