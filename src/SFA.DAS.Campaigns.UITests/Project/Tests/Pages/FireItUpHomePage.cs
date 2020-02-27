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

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By PageHeader => By.CssSelector(".homepage-title");

        public FireItUpHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
