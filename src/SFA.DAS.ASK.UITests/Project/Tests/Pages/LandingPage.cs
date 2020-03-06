using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project.Tests.Pages
{
    public class LandingPage : AskBasePage
    {
        protected override string PageTitle => "Request support from the ASK programme";

        protected override By ContinueButton => By.CssSelector("#startButton");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public LandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DoYouHaveDFEAccountPage StartNow()
        {
            Continue();
            return new DoYouHaveDFEAccountPage(_context);
        }
    }
}
