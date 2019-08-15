using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : MyAccountWithPaye
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By AccountId => By.CssSelector(".heading-secondary");

        private By SucessSummary => By.CssSelector(".success-summary");

        public HomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        public HomePage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

        protected override string PageTitle => _config.RE_OrganisationName.ToUpper();

        protected override string Linktext => "Home";

        public void VerifySucessSummary()
        {
            _pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountID()
        {
            return _pageInteractionHelper.GetText(AccountId);
        }
    }
}