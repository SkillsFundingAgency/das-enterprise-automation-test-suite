using System;
using System.Text.RegularExpressions;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations
{
    class SelectYourOrganisationPage : EnterOrganisationDetails
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

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

        public SelectYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal EnterOrganizationNamePage OpenEnterYourDetailsManually()
        {
            _formCompletionHelper.ClickElement(_enterYourDetailsManuallyLink);
            return new EnterOrganizationNamePage(WebBrowserDriver);
        }

        internal SelectYourOrganisationPage NextPage()
        {
            _formCompletionHelper.ClickElement(_nextPageButton);
            return this;
        }

        internal SelectYourOrganisationPage PreviousPage()
        {
            _formCompletionHelper.ClickElement(_previousPageButton);
            return this;
        }

        internal int GetResultsNumber()
        {
            var result = Regex.Match(this._resultsNumber.Text, ResultsNumberRegex).Value;
            return Convert.ToInt32(result);
        }

        internal SummaryPayePage SelectFirstResultWithConfirm()
        {
            _formCompletionHelper.ClickElement(_firstResultButton);
            return new SummaryPayePage(WebBrowserDriver);
        }

        internal FindOrganizationAddressPage SelectFirstResultWithFindAddressPage()
        {
            _formCompletionHelper.ClickElement(_firstResultButton);
            return new FindOrganizationAddressPage(WebBrowserDriver);
        }

        internal string OrganisationIsAdded()
        {
            return pageInteractionHelper.GetText(errorText);
        }
    }
}