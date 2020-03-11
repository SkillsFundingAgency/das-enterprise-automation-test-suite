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

        private By ApprenticeSearchField => By.Id("search-input");
        private By SearchButton => By.CssSelector(".submit-search");
        private By ApprenticesTable => By.ClassName("tableResponsive");
        private By SelectFilterDropdown => By.Id("selectedStatus");
        private By ApplyFilter => By.CssSelector(".govuk-button");
        private By ClearSearchAndFilters => By.PartialLinkText("Clear search");
        private By DownloadAllDataLink => By.PartialLinkText("Download all data");
        private By NextPageLink => By.PartialLinkText("Next");

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

            _tableRowHelper.SelectRowFromTable("View", _dataHelper.ApprenticeFullName);
            return new ApprenticeDetailsPage(_context);
        }

        private ManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            _formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);
            _formCompletionHelper.ClickElement(SearchButton);
            return this;
        }

        internal bool CheckIfApprenticeExists(bool isEdited = false)
        {
            if (isEdited)
                SearchForApprentice(_editedApprenticeDataHelper.ApprenticeEditedFullName);
            else
                SearchForApprentice(_dataHelper.Ulns.Single());

            return _pageInteractionHelper.IsElementDisplayed(ApprenticesTable);
        }

        public ManageYourApprenticesPage FilterPagination(string filterText)
        {
            _formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);
            _formCompletionHelper.ClickElement(ApplyFilter);
            _formCompletionHelper.ClickElement(NextPageLink);
            _formCompletionHelper.ClickElement(ClearSearchAndFilters);
            return this;
        }

        public bool DownloadAllDataLinkIsDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(DownloadAllDataLink);
        }
    }
}

