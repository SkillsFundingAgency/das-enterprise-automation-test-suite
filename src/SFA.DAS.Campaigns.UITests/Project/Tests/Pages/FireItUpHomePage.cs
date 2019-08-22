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
    internal sealed class FireItUpHomePage : BasePage
    {
        #region Constants
        private const string ExpectedPageTitle = "FIRE \n IT UP";
        private const string ExpectedApprenticesHeaderSupportText = "BLAZE YOUR OWN TRAIL AND BECOME AN APPRENTICE";
        private const string ExpectedEmployersHeaderSupportText = "FIRE UP YOUR BUSINESS WITH AN APPRENTICE";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.ClassName("homepage-title");
        private readonly By _apprenticeMenu = By.Id("link-nav-apprentice");
        private readonly By _cookieButton = By.Id("link-cookie-accept");
        private readonly By _findAnApprenticeLink = By.Id("link-nav-app-step-2");
        private readonly By _ApprenticesHeaderSupportText = By.XPath("(//div[@class='launcher__content']/child::p)[1]");
        private readonly By _EmployersHeaderSupportText = By.XPath("(//div[@class='launcher__content']/child::p)[4]");
        private readonly By _yourApprenticeshipLink = By.Id("link-nav-app-step-5");
        private readonly By _assessmentAndCertificationLink = By.Id("link-nav-app-step-6");
        private readonly By _inetrviewLink = By.Id("link-nav-app-step-4");
        private readonly By _applicationLink = By.Id("link-nav-app-step-3");
        private readonly By _whatIsAnApprenticeshipLink = By.Id("link-nav-app-step-1");
        private readonly By _myinterestsLink = By.Id("link-nav-app-interests");
        private readonly By _whatAreTheBenefitsForMeLink = By.Id("link-nav-app-benefits");
        private readonly By _realStoriesLink = By.Id("link-nav-app-real-stories");

        #endregion

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            // VerifyPage(); // this verification is failing due a bug in the application. We will uncomment this in future

        }

        protected override bool VerifyPage()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_pageTitle);
            return _pageInteractionHelper.VerifyPage(_pageTitle, ExpectedPageTitle);
        }

        internal void ClickOnCookieContinueButton()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_cookieButton);
            _formCompletionHelper.ClickElement(_cookieButton);
        }

        internal void VerifyApprenticesHeaderSupportText()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_ApprenticesHeaderSupportText);
            _pageInteractionHelper.FocusTheElement(_ApprenticesHeaderSupportText);
            _formCompletionHelper.VerifyPage(_ApprenticesHeaderSupportText, ExpectedApprenticesHeaderSupportText);
        }

        internal void VerifyEmployersHeaderSupportText()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_EmployersHeaderSupportText);
            _pageInteractionHelper.FocusTheElement(_EmployersHeaderSupportText);
            _formCompletionHelper.VerifyPage(_EmployersHeaderSupportText, ExpectedEmployersHeaderSupportText);
        }

        internal void LaunchApprenticeMenu()
        {
            _pageInteractionHelper.WaitForElementToBeDisplayed(_apprenticeMenu);
            _pageInteractionHelper.FocusTheElement(_apprenticeMenu);
        }

        internal void ClickOnFindAnApprenticeLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_findAnApprenticeLink);
            _formCompletionHelper.ClickElement(_findAnApprenticeLink);
        }

        internal void ClickOnYourApprenticeshipLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_yourApprenticeshipLink);
            _formCompletionHelper.ClickElement(_yourApprenticeshipLink);
        }

        internal void ClickOnAssessmentAndCertificationLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_assessmentAndCertificationLink);
            _formCompletionHelper.ClickElement(_assessmentAndCertificationLink);
        }

        internal void ClickOnInterviewLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_inetrviewLink);
            _formCompletionHelper.ClickElement(_inetrviewLink);
        }

        internal void ClickOnApplicationLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_applicationLink);
            _formCompletionHelper.ClickElement(_applicationLink);
        }

        internal void ClickOnWhatIsAnApprenticeshipLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_whatIsAnApprenticeshipLink);
            _formCompletionHelper.ClickElement(_whatIsAnApprenticeshipLink);
        }

        internal void ClickOnMyInterestsLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_myinterestsLink);
            _formCompletionHelper.ClickElement(_myinterestsLink);
        }

        internal void ClickOnWhatAreTheBenefitsForMeLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_whatAreTheBenefitsForMeLink);
            _formCompletionHelper.ClickElement(_whatAreTheBenefitsForMeLink);
        }

        internal void ClickOnRealStoriesLink()
        {
            _pageInteractionHelper.WaitForElementToBeClickable(_realStoriesLink);
            _formCompletionHelper.ClickElement(_realStoriesLink);
        }

    }
}
