using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class ApprenticeshipSummaryPage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        private const string ExpectedApprenticeshipSummaryHeader = "Apprenticeship summary";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _apprenticeshipSummaryHeader = By.XPath("(//div[@class='column-full']/child::h2)[1]");
        private readonly By _signInToApplyButton = By.XPath("//a[@id='apply-button']");
        private readonly By _vacancyTitle = By.XPath("//h1[@id='vacancy-title']");
        private readonly By _vacancyDescription = By.XPath("//p[@id='vacancy-description']");
        private readonly By _employerName = By.XPath("//h1[@id='vacancy-title']/span");
        private readonly By _possibleClosingDate = By.XPath("//p[@id='vacancy-start-date']");
        #endregion

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
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

        internal void verifyApprenticeSummaryPageHeader()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_apprenticeshipSummaryHeader);
            _pageInteractionHelper.VerifyPage(_apprenticeshipSummaryHeader, ExpectedApprenticeshipSummaryHeader);
        }

        internal void clickObSignInToApplyButton()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_signInToApplyButton);
            _formCompletionHelper.ClickElement(_signInToApplyButton);
        }

        internal void verifyApprenticeDetailsOfResultsPageAgainstSummaryPage()
        {
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.GetText(_vacancyTitle));
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.GetText(_vacancyDescription));
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.GetText(_employerName));
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.GetText(_possibleClosingDate));

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + PageInteractionCampaignsHelper.expectedVacancyTitle);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + PageInteractionCampaignsHelper.expectedVacancyDescription);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + PageInteractionCampaignsHelper.expectedEmployerName);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + PageInteractionCampaignsHelper.expectedPossibleClosingDate);

            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_vacancyTitle), PageInteractionCampaignsHelper.expectedVacancyTitle);
            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_vacancyDescription),PageInteractionCampaignsHelper.expectedVacancyDescription);
            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_employerName),PageInteractionCampaignsHelper.expectedEmployerName);
            //_pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_possibleClosingDate),PageInteractionCampaignsHelper.expectedPossibleClosingDate);

        }

    }
}
