using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public abstract class IdamsLoginBasePage : VerifyBasePage
    {
        protected By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        protected IdamsLoginBasePage(ScenarioContext context, bool verifypage = true): base(context)
        {
            if (verifypage) VerifyPage();
        }

        public void LoginToPireanPreprod() => formCompletionHelper.Click(PireanPreprod);

        protected void ClickIfPirenIsDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(PireanPreprod))
                LoginToPireanPreprod();
        }
    }
}
