using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations
{
    public class EnterOrganisationDetails : BasePage
    {
        protected const string searchInputId = "searchTerm";
        [FindsBy(How = How.Id, Using = searchInputId)]
        protected IWebElement searchInput;

        public EnterOrganisationDetails(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }
    }

    public class SearchForYourOrganisationPage : EnterOrganisationDetails
    {
        private const string searchButtoncss = "form > [type=\"submit\"]";
        [FindsBy(How = How.CssSelector, Using = searchButtoncss)] private IWebElement _searchButton;

        public SearchForYourOrganisationPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(searchInput);
        }

        internal SearchForYourOrganisationPage SetOrganisationName(string name)
        {
            formCompletionHelper.EnterText(searchInput, name);
            return this;
        }

        internal SelectYourOrganisationPage Continue()
        {
            formCompletionHelper.ClickElement(_searchButton);
            return new SelectYourOrganisationPage(WebBrowserDriver);
        }
    }
}