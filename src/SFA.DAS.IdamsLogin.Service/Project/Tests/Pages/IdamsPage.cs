using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class IdamsPage : BasePage
    {
        protected override string PageTitle => "Sign in using your account on:";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        private By Access1Staff => By.XPath("//span[contains(text(),'Access1 Staff')]");
        #endregion

        public IdamsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPageAfterRefresh(PireanPreprod);
        }

        public void LoginToPireanPreprod() => _formCompletionHelper.Click(PireanPreprod);

        public void LoginToAccess1Staff() => _formCompletionHelper.Click(Access1Staff);
    }
}
