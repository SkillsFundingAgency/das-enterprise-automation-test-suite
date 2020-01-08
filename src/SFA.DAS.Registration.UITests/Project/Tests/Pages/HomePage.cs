using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        #region Helpers and Context
        private readonly RegexHelper _regexHelper;
        #endregion

        private By PublicAccountIdLocator => By.CssSelector(".heading-secondary");

        private By SucessSummary => By.CssSelector(".success-summary");

        internal HomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _regexHelper = context.Get<RegexHelper>();
        }

        public HomePage(ScenarioContext context) : this(context, false)
        {
        }

        protected override string Linktext => "Home";

        public void VerifySucessSummary()
        {
            pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountId()
        {
            return _regexHelper.GetAccountId(pageInteractionHelper.GetUrl());
        }

        public string PublicAccountId()
        {
            return _regexHelper.GetPublicAccountId(pageInteractionHelper.GetText(PublicAccountIdLocator));
        }
    }
}