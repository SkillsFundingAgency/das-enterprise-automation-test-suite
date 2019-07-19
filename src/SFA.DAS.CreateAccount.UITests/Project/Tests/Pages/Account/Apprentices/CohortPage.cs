using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    public class CohortPage : BasePage
    {
        private By _cohortRequest => By.CssSelector("div.grid-row div span");

        public CohortPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool AreThereAnyActiveCohort()
        {
            return WebBrowserDriver.FindElements(_cohortRequest).ToList().All(activecohortcount => activecohortcount.Text == "0");
        }
    }
}