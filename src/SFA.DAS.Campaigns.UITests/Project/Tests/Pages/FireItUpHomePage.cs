using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class RegisterMyInterestPage : CampaingnsBasePage
    {
        protected override string PageTitle => "REGSITER MY INTEREST";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By EmailField => By.Id("Email");
        private By RadioButtons => By.CssSelector(".radios__label");
        private By CheckBox => By.CssSelector(".checkboxes__label");
        private By RegisterMyInterest => By.CssSelector("#btn-register-interest-complete");
        
        public RegisterMyInterestPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RegisterMyInterestSuccessPage RegisterInterestAsAnApprentice() => RegisterInterest("rbApprentice");
     
        public RegisterMyInterestSuccessPage RegisterInterestAsEmployer() => RegisterInterest("rbEmployer");

        private RegisterMyInterestSuccessPage RegisterInterest(string userRole)
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButtons, userRole);
            formCompletionHelper.SelectRadioOptionByForAttribute(CheckBox, "AcceptTandCs");
            formCompletionHelper.ClickElement(RegisterMyInterest);
            return new RegisterMyInterestSuccessPage(_context);
        }
    }

    public class FireItUpHomePage : CampaingnsBasePage
    {
        protected override string PageTitle => "FIRE";

        protected override By PageHeader => By.CssSelector(".homepage-title");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CookieButton => By.CssSelector("#link-cookie-accept");

        private By RegisterInterest => By.CssSelector("a[href*='register-interest']");

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FireItUpHomePage AcceptCookie()
        {
            formCompletionHelper.ClickElement(CookieButton);
            return new FireItUpHomePage(_context);
        }

        public RegisterMyInterestPage NavigateToRegisterInterest()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterMyInterestPage(_context);
        }
    }
}
