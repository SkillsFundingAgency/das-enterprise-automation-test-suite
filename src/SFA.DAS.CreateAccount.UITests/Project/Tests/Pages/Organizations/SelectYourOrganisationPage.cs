using System;
using System.Text.RegularExpressions;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations
{
    class SelectYourOrganisationPage : EnterOrganisationDetails
    {
        private const string ResultsNumberRegex = "\\d+(?= results found)";
        private const string resultListcss = ".results-list";
        [FindsBy(How = How.CssSelector, Using = resultListcss)]
        private IWebElement _resultList;
        private const string firstResultButtoncss = ".results-list form:first-child > [type=\"submit\"]";
        [FindsBy(How = How.CssSelector, Using = firstResultButtoncss)]
        private IWebElement _firstResultButton;
        [FindsBy(How = How.CssSelector, Using = ".results-list a[href$=manualAdd]")]
        private IWebElement _enterYourDetailsManuallyLink;
        [FindsBy(How = How.CssSelector, Using = "#content .column-two-thirds p:last-child")]
        private IWebElement _resultsNumber;
        [FindsBy(How = How.CssSelector, Using = ".results-list .next a")]
        private IWebElement _nextPageButton;
        [FindsBy(How = How.CssSelector, Using = ".results-list .previous a")]
        private IWebElement _previousPageButton;
        private By errorText = By.XPath("(//section[@class=\'results-list\']//p)[1]");

        public SelectYourOrganisationPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal EnterOrganizationNamePage OpenEnterYourDetailsManually()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _enterYourDetailsManuallyLink);
            return new EnterOrganizationNamePage(WebBrowserDriver);
        }

        internal SelectYourOrganisationPage NextPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _nextPageButton);
            return this;
        }

        internal SelectYourOrganisationPage PreviousPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _previousPageButton);
            return this;
        }

        internal int GetResultsNumber()
        {
            var result = Regex.Match(this._resultsNumber.Text, ResultsNumberRegex).Value;
            return Convert.ToInt32(result);
        }

        internal SummaryPayePage SelectFirstResultWithConfirm()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _firstResultButton);
            return new SummaryPayePage(WebBrowserDriver);
        }

        internal FindOrganizationAddressPage SelectFirstResultWithFindAddressPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _firstResultButton);
            return new FindOrganizationAddressPage(WebBrowserDriver);
        }

        internal string OrganisationIsAdded()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, errorText);
        }
    }
}