using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ToolSupportHomePage : ToolSupportBasePage
    {
        protected override string PageTitle => "DAS Tools Support";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        /*protected override By PageHeader => By.CssSelector(".heading-large");
        private By SearchOptionsLabels => By.CssSelector("label");
        private By SearchButton => By.Id("searchButton");
        private By SearchTextBox => By.Id("search-main");
        private By NextPage => By.CssSelector(".page-navigation .next");
        private By NoOfPages => By.CssSelector(".page-navigation .next .counter");*/
        #endregion

        private string AccountSearchHint => "Enter account name, account ID or PAYE scheme";
        private string UserSearchHint => "Enter name or email address";

        public ToolSupportHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }


    }
}
