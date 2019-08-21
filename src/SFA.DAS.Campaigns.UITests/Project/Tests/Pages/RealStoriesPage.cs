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
    internal sealed class RealStoriesPage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "REAL STORIES";
        private const string ExpectedRealStoriesDescription = "Do you want to earn while you learn and get hands-on experience? Have a look at real stories and see how becoming an apprentice changed the following lives.";
        private const string ExpectedTotalTimeDurationForVideo1 = "1:02";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionCampaignsHelper _pageInteractionCampaignsHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='heading-xl hero-heading__heading']");
        private readonly By _realStoriesDescription = By.ClassName("lead-paragraph");
        private readonly By _video1Url = By.Id("play-1");
        private readonly By _video1PlayButton = By.XPath("//button[@class='ytp-large-play-button ytp-button']");
        private readonly By _playOrPauseButton = By.XPath("//button[@class='ytp-play-button ytp-button']");
        private readonly By _soundIcon = By.XPath("//button[@class='ytp-mute-button ytp-button']");
        private readonly By _totalTimeDuration = By.XPath("//span[@class='ytp-time-duration']");
        private readonly By _fullScreenIcon = By.XPath("//button[@class='ytp-fullscreen-button ytp-button']");
        #endregion

        public RealStoriesPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionCampaignsHelper = context.Get<PageInteractionCampaignsHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(_pageTitle, ExpectedPageTitle);
        }

        internal void verifyContentUnderRealStoriesHeader()
        {
            string actualRealStoriesDescription = _pageInteractionHelper.GetText(_realStoriesDescription);
            _pageInteractionHelper.VerifyText(actualRealStoriesDescription, ExpectedRealStoriesDescription);
        }

        internal void playTheFirstVideo()
        {
           _pageInteractionCampaignsHelper.navigateToAnyVideoUrl(_video1Url);
            _formCompletionHelper.ClickElement(_video1PlayButton);
            _formCompletionHelper.ClickElement(_playOrPauseButton);
            _formCompletionHelper.ClickElement(_soundIcon);
            _formCompletionHelper.ClickElement(_soundIcon);
            string actualTotalTimeDurationForVideo1 = _pageInteractionHelper.GetText(_totalTimeDuration);
            _pageInteractionHelper.VerifyText(actualTotalTimeDurationForVideo1, ExpectedTotalTimeDurationForVideo1);
            _formCompletionHelper.ClickElement(_fullScreenIcon);
            _formCompletionHelper.ClickElement(_fullScreenIcon);
            _formCompletionHelper.ClickElement(_playOrPauseButton);
            _pageInteractionCampaignsHelper.navigateBack();
        }

    }
}
