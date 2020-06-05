using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class IdamsPage : IdamsLoginBasePage
    {
        protected override string PageTitle => "Sign in using your account on:";

        #region Locators
        private By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        private By Access1Staff => By.XPath("//span[contains(text(),'Access1 Staff')]");
        #endregion

        public IdamsPage(ScenarioContext context) : base(context, false) => VerifyPageAfterRefresh(PireanPreprod);

        public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);

        public void LoginToAccess1Staff() => formCompletionHelper.Click(Access1Staff);
    }
}
