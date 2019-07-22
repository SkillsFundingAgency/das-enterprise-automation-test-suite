using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class YourResultsPage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        private const String ExpectedHeaderWhenNoResultsFound = "NO MATCHING RESULTS...";
        private const String ExpectedHeaderWhenResultsFound = "YOUR RESULTS...";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        #endregion

        #region Page Object Elements
        private readonly By _resultsHeader = By.XPath("//h1[@class='heading-l']");
        private readonly By _firstSearchResult = By.XPath("//ol[@id='vacancy-search-results']/li[1]/h2/a");
        private readonly By _postCodeBox = By.XPath("//input[@id='Postcode']");
        private readonly By _updateResultsButton = By.XPath("//input[@id='button-faa-update-results']");
        #endregion

        public YourResultsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), PageTitle);
        }

        internal bool IsPageMatching()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), PageTitle);
        }

        internal void verifyResultsPageHeader()
        {
            string actualResultsHeader = _pageInteractionHelper.GetText(_resultsHeader);
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + actualResultsHeader);
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + ExpectedHeaderWhenResultsFound);
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.VerifyPage(actualResultsHeader, ExpectedHeaderWhenResultsFound, ExpectedHeaderWhenNoResultsFound));

            _pageInteractionHelper.VerifyPage(actualResultsHeader, ExpectedHeaderWhenResultsFound, ExpectedHeaderWhenNoResultsFound);
        }

        internal void clickOnFirstSearchResult()
        {
            _formCompletionHelper.WaitForPageToLoad(10);
            _formCompletionHelper.ClickElement(_firstSearchResult);
            System.Threading.Thread.Sleep(10000);
            _pageInteractionCampaignsHelper.switchToANewTab();

            /*bool resultsStatus = _pageInteractionHelper.VerifyText(_headerWhenResultsFound, expectedHeaderWhenResultsFound);
            if (resultsStatus)
            {
                _formCompletionHelper.ClickElement(_firstSearchResult);
            }
            else
            {
                enterPostCode();
                clickOnUpdateResultsButton();
            }*/
        }

        internal void enterPostCode()
        {
            _formCompletionHelper.EnterText(_postCodeBox,"TW33JW");
        }

        internal void clickOnUpdateResultsButton()
        {
            _formCompletionHelper.ClickElement(_updateResultsButton);
        }

    }
}
