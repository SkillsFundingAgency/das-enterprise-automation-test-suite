using System;
using BoDi;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class WelcomeToGovUkPage : BasePage
    {
        private static String PAGE_TITLE = "Welcome to GOV.UK";

        public WelcomeToGovUkPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            PageInteractionHelper p = new PageInteractionHelper(webDriver);

            return p.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By searchField = By.Name("q");
        private By searchButton = By.CssSelector(".gem-c-search__submit");

        internal SearchResultsPage EnterSearchTextAndSubmit(String searchText)
        {
            FormCompletionHelper f = new FormCompletionHelper(webDriver);
            f.EnterText(searchField, searchText);
            f.ClickElement(searchButton);
            return new SearchResultsPage(webDriver);
        }
    }
}