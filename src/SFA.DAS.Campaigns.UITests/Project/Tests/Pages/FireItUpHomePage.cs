using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class FireItUpHomePage : CampaingnsBasePage
    {
        protected override string PageTitle => "FIRE";

        protected override By PageHeader => By.CssSelector(".homepage-title");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CookieButton => By.CssSelector("#link-cookie-accept");

        private By DoNotAlert => By.CssSelector("#alert-countries-stay");

        private By Apprentice => By.CssSelector("a[href*='apprentice']");

        private By Employer => By.CssSelector("a[href*='employer']");
        
        private By Parent => By.CssSelector("a[href*='parents']");
        
        private By Interests => By.CssSelector("a[href*='industries']");

        private By RegisterInterest => By.CssSelector("a[href*='register-interest']");

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FireItUpHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
                formCompletionHelper.ClickElement(CookieButton);

            if (pageInteractionHelper.WaitUntilAnyElements(DoNotAlert))
                formCompletionHelper.ClickElement(DoNotAlert);
            
            return new FireItUpHomePage(_context);
        }

        public RegisterInterestPage NavigateToRegisterInterest()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }

        public HelpShapeTheirCareerPage NavigateToHelpShapeTheirCareerPage()
        {
            formCompletionHelper.ClickElement(Parent);
            return new HelpShapeTheirCareerPage(_context);
        }
    }
}
