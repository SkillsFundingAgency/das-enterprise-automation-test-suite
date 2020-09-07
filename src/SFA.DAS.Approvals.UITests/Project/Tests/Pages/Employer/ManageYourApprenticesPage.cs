using System;
using System.Linq;
using NUnit.Framework;
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
        private By ApprenticesTable => By.CssSelector("table.govuk-table.das-table--responsive");
        private By SelectFilterDropdown => By.Id("selectedStatus");
        private By ApplyFilter => By.CssSelector("#main-content .govuk-button");
        private By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");
        private By NextPageLink => By.PartialLinkText("Next");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeFullName => By.PartialLinkText(apprenticeDataHelper.ApprenticeFullName);
        private By Status => By.CssSelector("#main-content tbody tr td:nth-child(6)");
        public ManageYourApprenticesPage(ScenarioContext context): base(context) => _context = context;

        internal ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);

            var apprenticeRows = pageInteractionHelper.FindElements(ApprenticeInfoRow);
            var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName);

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
            formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
            formCompletionHelper.ClickElement(SearchButton);
            return new ManageYourApprenticesPage(_context);
        }

        internal void VerifyApprenticeExists()
        {
            pageInteractionHelper.Verify(() =>
            {
                return pageInteractionHelper.FindElements(ApprenticesTable).Any();
            }, () => SearchForApprentice(editedApprenticeDataHelper.ApprenticeEditedFullName));
        }

        public ManageYourApprenticesPage Filter(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            formCompletionHelper.ClickElement(ApplyFilter);
            return new ManageYourApprenticesPage(_context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        public void ValidateStatus(string expectedStatus)
        {
            var actStatus = pageInteractionHelper.GetText(Status);
            Assert.AreEqual(pageInteractionHelper.GetText(Status), expectedStatus, "Validate Status of the apprenticeship on Manage Your Apprentice Page");
        }
    
    }
}

