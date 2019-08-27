using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimBasePage
    {
        protected override string PageTitle => config.RE_OrganisationName.ToUpper();

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RegexHelper _regexHelper;
        #endregion

        private By PublicAccountId => By.CssSelector(".heading-secondary");

        private By SucessSummary => By.CssSelector(".success-summary");

        
        internal HomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
        }

        protected override string Linktext => "Home";

        public void VerifySucessSummary()
        {
            pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountID()
        {
            return _regexHelper.GetAccountId(pageInteractionHelper.GetUrl());
        }
    }
}