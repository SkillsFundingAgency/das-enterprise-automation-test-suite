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
    }
}

