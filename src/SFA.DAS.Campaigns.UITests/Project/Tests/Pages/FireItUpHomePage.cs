using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal sealed class FireItUpHomePage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Page Object Elements
        private readonly By _apprenticeMenu = By.XPath("//a[@id='link-nav-apprentice']");
        private readonly By _cookieButton = By.XPath("//a[@id='link-cookie-accept']");
        private readonly By _findAnApprenticeLink = By.XPath("//a[@id='link-nav-app-step-2']");
        #endregion

        public FireItUpHomePage(ScenarioContext context) : base(context)
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

        internal void clickOnCookieContinueButton()
        {
            _formCompletionHelper.ClickElement(_cookieButton);
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
