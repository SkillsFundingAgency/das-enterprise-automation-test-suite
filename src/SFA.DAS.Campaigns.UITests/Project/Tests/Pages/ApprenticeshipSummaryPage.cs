using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class ApprenticeshipSummaryPage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "Apprenticeship summary";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _apprenticeshipSummaryHeader = By.XPath("(//div[@class='column-full']/child::h2)[1]");
        private readonly By _signInToApplyButton = By.Id("apply-button");
        private readonly By _vacancyTitle = By.Id("vacancy-title");
        private readonly By _vacancyDescription = By.Id("vacancy-description");
        private readonly By _employerName = By.XPath("//h1[@id='vacancy-title']/span");
        private readonly By _possibleClosingDate = By.Id("vacancy-start-date");
        #endregion

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(_apprenticeshipSummaryHeader, ExpectedPageTitle);
        }

        internal void ClickObSignInToApplyButton()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_signInToApplyButton);
            _formCompletionHelper.ClickElement(_signInToApplyButton);
        }

        internal void VerifyApprenticeDetailsOfResultsPageAgainstSummaryPage()
        {
            _pageInteractionHelper.FocusTheElement(_vacancyTitle);
            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_vacancyTitle), PageInteractionCampaignsHelper.expectedVacancyTitle);
            _pageInteractionHelper.FocusTheElement(_vacancyDescription);
            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_vacancyDescription),PageInteractionCampaignsHelper.expectedVacancyDescription);
            _pageInteractionHelper.FocusTheElement(_employerName);
            _pageInteractionHelper.VerifyText(_pageInteractionHelper.GetText(_employerName),PageInteractionCampaignsHelper.expectedEmployerName);

            _pageInteractionHelper.FocusTheElement(_possibleClosingDate);
            string dateFromResultsPage = _pageInteractionHelper.GetText(_possibleClosingDate);
            DateTime convertedDate = Convert.ToDateTime(dateFromResultsPage);
            string formattedDate = convertedDate.ToShortDateString();
            _pageInteractionHelper.VerifyText(formattedDate, PageInteractionCampaignsHelper.expectedPossibleClosingDate);

        }

    }
}
