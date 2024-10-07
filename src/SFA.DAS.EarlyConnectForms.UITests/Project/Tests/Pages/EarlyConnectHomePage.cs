using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EarlyConnectHomePage(ScenarioContext context) : VerifyBasePage(context)
    {
        protected override string PageTitle => "Get an apprenticeship adviser";

        protected override By PageHeader => By.CssSelector(".fiu-header");

        private static By CookieButton => By.CssSelector("div[class='das-cookie-banner__wrapper govuk-width-container'] button:nth-child(1)");

        private static By CloseCookieButton => By.CssSelector("#btn-hide-cookie-banner");

        protected static By GetAnAdvisorInLancashire => By.CssSelector("li:nth-child(1) a:nth-child(1)");
        protected static By GetAnAdvisorInNorthEast => By.CssSelector("li:nth-child(2) a:nth-child(1)");

        public EarlyConnectHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new EarlyConnectHomePage(context);
        }

        public EarlyConnectHomePage SelectNorthEast()
        {
            formCompletionHelper.Click(GetAnAdvisorInNorthEast);
            return new EarlyConnectHomePage(context);
        }
    }
}
