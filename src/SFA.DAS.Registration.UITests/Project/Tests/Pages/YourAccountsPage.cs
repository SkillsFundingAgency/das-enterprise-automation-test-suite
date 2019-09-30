using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAccountsPage : BasePage
    {
        protected override string PageTitle => "Your accounts";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By AddNewAccountButton => By.Id("add_new_account");

        private By OpenLink() => By.CssSelector("table a");

        public YourAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public GatewayInformPage AddNewAccount()
        {
            _formCompletionHelper.ClickElement(AddNewAccountButton);
            return new GatewayInformPage(_context);
        }

        public HomePage GoToHomePage(string organisationName)
        {
            _formCompletionHelper.ClickElement(SearchLinkUrl(organisationName));
            return new HomePage(_context);
        }

        private IWebElement SearchLinkUrl(string searchText) => _pageInteractionHelper.GetLinkContains(OpenLink(), searchText);
    }
}