using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class HomePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly PayeAccountDetails _config;
        #endregion

        private By AccountId => By.CssSelector(".heading-secondary");

        public HomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetConfigSection<PayeAccountDetails>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => _config.OrganisationName.ToUpper();

        public string AccountID()
        {
            return _pageInteractionHelper.GetText(AccountId);
        }
    }
}