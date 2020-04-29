using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourApprenticesPage : BasePage
    {
        protected override string PageTitle => "Manage your apprentices";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly EditedApprenticeDataHelper _editedApprenticeDataHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By ApprenticeSearchField => By.Id("searchTerm");
        private By SearchButton => By.ClassName("das-search-form__button");
        private By ApprenticesTable => By.CssSelector("table.govuk-table.das-table--responsive");
        private By SelectFilterDropdown => By.Id("selectedStatus");
        private By ApplyFilter => By.CssSelector("#main-content .govuk-button");
        private By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");
        private By NextPageLink => By.PartialLinkText("Next");
        private By ApprenticeInfoRow => By.CssSelector("tbody tr");
        private By ViewApprenticeFullName => By.PartialLinkText(_dataHelper.ApprenticeFullName);

        public ManageYourApprenticesPage(ScenarioContext context): base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        internal ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            SearchForApprentice(_dataHelper.ApprenticeFirstname);

            var apprenticeRows = _pageInteractionHelper.FindElements(ApprenticeInfoRow);
            var detailsLinks = _pageInteractionHelper.FindElement(ViewApprenticeFullName);

            int i = 0;
            foreach (IWebElement apprenticeRow in apprenticeRows)
            {
                if (apprenticeRow.Text.Contains(_dataHelper.ApprenticeFullName))
                {
                    _formCompletionHelper.ClickElement(detailsLinks);
                    return new ApprenticeDetailsPage(_context);
                }
                i++;
            }
            if (_pageInteractionHelper.IsElementDisplayed(NextPageLink))
            {
                _formCompletionHelper.ClickElement(NextPageLink);
            }
            else
            {
                throw new Exception("Apprentice with - " + _dataHelper.ApprenticeFullName + " - name is not found");
            }

            return new ApprenticeDetailsPage(_context);
        }

        private ManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            _formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
            _formCompletionHelper.ClickElement(SearchButton);
            return new ManageYourApprenticesPage(_context);
        }

        internal void VerifyApprenticeExists()
        {
            _pageInteractionHelper.Verify(() =>
            {
                return _pageInteractionHelper.FindElements(ApprenticesTable).Any();
            }, () => SearchForApprentice(_editedApprenticeDataHelper.ApprenticeEditedFullName));
        }

        public ManageYourApprenticesPage Filter(string filterText)
        {
            _formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            _formCompletionHelper.ClickElement(ApplyFilter);
            return new ManageYourApprenticesPage(_context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => _pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);
    }
}

