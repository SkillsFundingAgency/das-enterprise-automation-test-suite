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
        private const string ExpectedPageTitle = "";
        private const string ExpectedApprenticesHeaderSupportText = "Blaze your own trail and become an apprentice";
        private const string ExpectedEmployersHeaderSupportText = "Fire up your business with an apprentice";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _apprenticeMenu = By.XPath("//a[@id='link-nav-apprentice']");
        private readonly By _cookieButton = By.XPath("//a[@id='link-cookie-accept']");
        private readonly By _findAnApprenticeLink = By.XPath("//a[@id='link-nav-app-step-2']");
        private readonly By _ApprenticesHeaderSupportText = By.XPath("(//div[@class='launcher__content']/child::p)[1]");
        private readonly By _EmployersHeaderSupportText = By.XPath("(//div[@class='launcher__content']/child::p)[2]");
        #endregion

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& "+ this.GetPageHeading());
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + ExpectedPageTitle);
            TestContext.Progress.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + _pageInteractionHelper.VerifyPage(this.GetPageHeading(), ExpectedPageTitle));

            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), ExpectedPageTitle);
        }

        internal bool IsPageMatching()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), ExpectedPageTitle);
        }

        internal void clickOnCookieContinueButton()
        {
            _formCompletionHelper.ClickElement(_cookieButton);
        }

        internal void verifyApprenticesHeaderSupportText()
        {
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& " + ExpectedApprenticesHeaderSupportText);
            _formCompletionHelper.VerifyPage(_ApprenticesHeaderSupportText, ExpectedApprenticesHeaderSupportText);
        }

        internal void verifyEmployersHeaderSupportText()
        {
            _formCompletionHelper.VerifyPage(_EmployersHeaderSupportText, ExpectedEmployersHeaderSupportText);
        }

        internal void launchApprenticeMenu()
        {
            _pageInteractionHelper.FocusTheElement(_apprenticeMenu);
        }

        internal void clickOnFindAnApprenticeLink()
        {
            _formCompletionHelper.ClickElement(_findAnApprenticeLink);
        }

    }
}
