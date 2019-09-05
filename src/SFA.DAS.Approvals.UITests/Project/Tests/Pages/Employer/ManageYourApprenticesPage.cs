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
        private readonly ApprovalsDataHelper _dataHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ApprenticeSearchField => By.Id("search-input");
        private By SearchButton => By.CssSelector(".submit-search");
        private By ApprenticesTable => By.ClassName("tableResponsive");

        public ManageYourApprenticesPage(ScenarioContext context): base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
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
    }
}

