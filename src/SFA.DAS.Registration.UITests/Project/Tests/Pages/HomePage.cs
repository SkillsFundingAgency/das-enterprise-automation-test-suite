using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : MyAccountWithPaye
    {
        protected override string PageTitle => config.RE_OrganisationName.ToUpper();

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By PublicAccountId => By.CssSelector(".heading-secondary");

        private By SucessSummary => By.CssSelector(".success-summary");

        public HomePage(ScenarioContext context): base(context)
        {
            _context = context;
        }

        public HomePage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

        protected override string Linktext => "Home";

        public void VerifySucessSummary()
        {
            pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountID()
        {
            return pageInteractionHelper.GetText(PublicAccountId);
        }
    }
}