using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class YourResultsPage : BasePage
    {
        #region Constants
        private const string ExpectedHeaderWhenNoResultsFound = "NO MATCHING RESULTS...";
        private const string ExpectedHeaderWhenResultsFound = "YOUR RESULTS...";
        private const string ExpectedParagraphOneText = "Try expanding your search location or changing your area of interest.";
        private const string ExpectedParagraphTwoText = "Alternatively, visit Find an apprenticeship to refine your search further.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        private ArrayList postCodeList = new ArrayList();
        #endregion

        #region Page Object Elements
        private readonly By _resultsHeader = By.ClassName("heading-l");
        private readonly By _firstSearchResult = By.XPath("//ol[@id='vacancy-search-results']/li[1]/h2/a");
        private readonly By _postCodeBox = By.Id("Postcode");
        private readonly By _updateResultsButton = By.Id("button-faa-update-results");
        private readonly By _noMatchResultParagraphOne = By.XPath("//div[@class='search-results']/p[1]");
        private readonly By _noMatchResultParagraphTwo = By.XPath("//div[@class='search-results']/p[2]");
        private readonly By _vacancyTitle = By.XPath("//ol[@id='vacancy-search-results']/li[1]/ul/li[1]");
        private readonly By _vacancyDescription = By.XPath("//ol[@id='vacancy-search-results']/li[1]/p");
        private readonly By _employerName = By.XPath("//ol[@id='vacancy-search-results']/li[1]/div/div[1]/dl/dd[1]");
        private readonly By _possibleClosingDate = By.XPath("//ol[@id='vacancy-search-results']/li[1]/div/div[1]/dl/dd[4]/span");
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
            return _pageInteractionHelper.VerifyPage(_pageInteractionHelper.GetText(_resultsHeader), ExpectedHeaderWhenResultsFound, ExpectedHeaderWhenNoResultsFound);
        }

        internal void verifyResultsPageHeader()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_resultsHeader);
            string actualResultsHeader = _pageInteractionHelper.GetText(_resultsHeader);
            _pageInteractionHelper.VerifyPage(actualResultsHeader, ExpectedHeaderWhenResultsFound, ExpectedHeaderWhenNoResultsFound);
        }

        internal void clickOnAnySerachResult()
        {
            postCodeList.Add("SW1V 3LP");
            postCodeList.Add("M1 4WB");
            postCodeList.Add("G1 1YU");
            postCodeList.Add("EH2 4AD");
            postCodeList.Add("NN1 1SR");
            postCodeList.Add("CV1 4AH");
            postCodeList.Add("BS1 3LE");
            postCodeList.Add("SN1 1LF");
            postCodeList.Add("YO1 7DT");
            postCodeList.Add("LS1 4AG");
            postCodeList.Add("TW3 3JW");

            for (int i=0; i < postCodeList.Count; i++)
            {
                _pageInteractionHelper.WaitForElementToBeDisplayed(_resultsHeader);
                if (_pageInteractionHelper.GetText(_resultsHeader).Contains(ExpectedHeaderWhenResultsFound))
                {
                    extractApprenticeDetailsFromResultsPage();
                    clickOnFirstSearchResult();
                    Console.WriteLine(" Results found in "+i+" th time");
                    break;
                }
                else
                {
                    enterPostCode((string)postCodeList[i]);
                    clickOnUpdateResultsButton();
                }
            }
        }

        internal void clickOnFirstSearchResult()
        {
            _formCompletionHelper.WaitForPageToLoad(10);
            _pageInteractionHelper.WaitForElementToBeDisplayed(_firstSearchResult);
            _formCompletionHelper.ClickElement(_firstSearchResult);
            _pageInteractionCampaignsHelper.switchToANewTab();
        }

        internal void enterPostCode(string postcode)
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_postCodeBox);
            _formCompletionHelper.EnterText(_postCodeBox,postcode);

        }

        internal void clickOnUpdateResultsButton()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_updateResultsButton);
            _formCompletionHelper.ClickElement(_updateResultsButton);
        }

        internal void findNoMatchingResultsPage()
        {
            postCodeList.Add("SW1V3LP");
            postCodeList.Add("M14WB");
            postCodeList.Add("G11YU");
            postCodeList.Add("EH24AD");
            postCodeList.Add("NN11SR");
            postCodeList.Add("CV14AH");
            postCodeList.Add("BS13LE");
            postCodeList.Add("SN11LF");
            postCodeList.Add("YO17DT");
            postCodeList.Add("LS14AG");
            postCodeList.Add("TW33JW");

            for (int i = 0; i < postCodeList.Count; i++)
            {
                _pageInteractionHelper.WaitForElementToBeDisplayed(_resultsHeader);
                if (_pageInteractionHelper.GetText(_resultsHeader).Contains(ExpectedHeaderWhenNoResultsFound))
                {
                    verifyTheNoMatchResultsPageContent();
                    break;
                }
                else
                {
                    enterPostCode((string)postCodeList[i]);
                    clickOnUpdateResultsButton();
                }
            }
        }

        internal void verifyTheNoMatchResultsPageContent()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_noMatchResultParagraphOne);
            _pageInteractionHelper.VerifyText(_noMatchResultParagraphOne, ExpectedParagraphOneText);
            _pageInteractionHelper.WaitForElementToBeDisplayed(_noMatchResultParagraphTwo);
            _pageInteractionHelper.VerifyText(_noMatchResultParagraphTwo, ExpectedParagraphTwoText);
        }

        internal void extractApprenticeDetailsFromResultsPage()
        {
            PageInteractionCampaignsHelper.expectedVacancyTitle = _pageInteractionHelper.GetText(_vacancyTitle);
            PageInteractionCampaignsHelper.expectedVacancyDescription = _pageInteractionHelper.GetText(_vacancyDescription);
            PageInteractionCampaignsHelper.expectedEmployerName = _pageInteractionHelper.GetText(_employerName);
            PageInteractionCampaignsHelper.expectedPossibleClosingDate = _pageInteractionHelper.GetText(_possibleClosingDate);
        }

    }
}
