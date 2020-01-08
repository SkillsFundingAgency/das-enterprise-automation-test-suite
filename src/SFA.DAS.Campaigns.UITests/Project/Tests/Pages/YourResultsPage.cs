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
        protected override string PageTitle => "NO MATCHING RESULTS...";

        #region Constants
        private const string ExpectedHeaderWhenNoResultsFound = "NO MATCHING RESULTS...";
        private const string ExpectedHeaderWhenResultsFound = "YOUR RESULTS...";
        private const string ExpectedParagraphOneText = "Try expanding your search location or changing your area of interest.";
        private const string ExpectedParagraphTwoText = "Alternatively, visit Find an apprenticeship on GOV.UK to refine your search further.";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        private ArrayList postCodeList = new ArrayList();
        #endregion

        #region Page Object Elements
        private readonly By _resultsHeader = By.XPath("//div[@class='search-results']/h1");
        private readonly By _firstSearchResult = By.XPath("//ol[@id='vacancy-search-results']/li[1]/h2/a");
        private readonly By _postCodeBox = By.Id("Postcode");
        private readonly By _updateResultsButton = By.Id("button-faa-update-results");
        private readonly By _noMatchResultParagraphOne = By.XPath("//div[@class='search-results']/p[1]");
        private readonly By _noMatchResultParagraphTwo = By.XPath("//div[@class='search-results']/p[2]");
        private readonly By _vacancyTitle = By.ClassName("link-faa-more-details-title");
        private readonly By _vacancyDescription = By.XPath("//ol[@id='vacancy-search-results']/li[1]/p");
        private readonly By _employerName = By.XPath("//ol[@id='vacancy-search-results']/li[1]/div/div[1]/dl/dd[1]");
        private readonly By _possibleClosingDate = By.XPath("//ol[@id='vacancy-search-results']/li[1]/div/div[1]/dl/dd[4]/span");
        #endregion

        public YourResultsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
        }

        internal void VerifyResultsPageHeader()
        {
            string actualResultsHeader = _pageInteractionHelper.GetText(_resultsHeader);
            _pageInteractionHelper.VerifyPage(actualResultsHeader, ExpectedHeaderWhenResultsFound, ExpectedHeaderWhenNoResultsFound);
        }

        internal void ClickOnAnySerachResult()
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
                if (_pageInteractionHelper.GetText(_resultsHeader).Contains(ExpectedHeaderWhenResultsFound))
                {
                    ExtractApprenticeDetailsFromResultsPage();
                    ClickOnFirstSearchResult();
                    Console.WriteLine(" Results found in "+i+" th time");
                    break;
                }
                else
                {
                    EnterPostCode((string)postCodeList[i]);
                    ClickOnUpdateResultsButton();
                }
            }
        }

        internal void ClickOnFirstSearchResult()
        {
            
            _formCompletionHelper.ClickElement(_firstSearchResult);
            _pageInteractionCampaignsHelper.SwitchToANewTab();
        }

        internal void EnterPostCode(string postcode)
        {
            _formCompletionHelper.EnterText(_postCodeBox,postcode);

        }

        internal void ClickOnUpdateResultsButton()
        {
            _formCompletionHelper.ClickElement(_updateResultsButton);
        }

        internal void FindNoMatchingResultsPage()
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
                if (_pageInteractionHelper.GetText(_resultsHeader).Contains(ExpectedHeaderWhenNoResultsFound))
                {
                    VerifyTheNoMatchResultsPageContent();
                    break;
                }
                else
                {
                    EnterPostCode((string)postCodeList[i]);
                    ClickOnUpdateResultsButton();
                }
            }
        }

        internal void VerifyTheNoMatchResultsPageContent()
        {
            _pageInteractionHelper.VerifyText(_noMatchResultParagraphOne, ExpectedParagraphOneText);
            _pageInteractionHelper.VerifyText(_noMatchResultParagraphTwo, ExpectedParagraphTwoText);
        }

        internal void ExtractApprenticeDetailsFromResultsPage()
        {
            PageInteractionCampaignsHelper.expectedVacancyTitle = _pageInteractionHelper.GetText(_vacancyTitle);
            PageInteractionCampaignsHelper.expectedVacancyDescription = _pageInteractionHelper.GetText(_vacancyDescription);
            PageInteractionCampaignsHelper.expectedEmployerName = _pageInteractionHelper.GetText(_employerName);
            PageInteractionCampaignsHelper.expectedPossibleClosingDate = _pageInteractionHelper.GetText(_possibleClosingDate);
        }

    }
}
