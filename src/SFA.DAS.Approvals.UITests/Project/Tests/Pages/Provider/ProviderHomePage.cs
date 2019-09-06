using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => config.AP_ProviderUkprn;

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsDataHelper _dataHelper;
        #endregion

        protected override By PageHeader => By.CssSelector("#content .grey-text");

        protected override string Linktext => "Home";

        private By ProviderManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        public ProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ProviderManageYourApprenticesPage GoToProviderManageYourApprenticePage()
        {
            _formCompletionHelper.ClickElement(ProviderManageYourApprenticesLink);
            return new ProviderManageYourApprenticesPage(_context);
        }
    }
}
