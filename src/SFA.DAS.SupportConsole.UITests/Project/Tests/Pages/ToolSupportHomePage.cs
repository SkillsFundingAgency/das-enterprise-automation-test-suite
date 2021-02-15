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
        private By HomeHeading => By.LinkText("support");
        protected By PauseApprenticeshipsLink => By.XPath("//body/div[1]/main[1]/div[1]/div[1]/dl[1]/div[1]/dd[2]/a[1]");
        protected By ResumeApprenticeshipsLink => By.PartialLinkText("act=resume");
        protected By StopApprenticeshipsLink => By.PartialLinkText("act=stop");
        #endregion

        public ToolSupportHomePage(ScenarioContext context) : base(context) => _context = context;

        public void ClickPauseApprenticeshipsLink() => formCompletionHelper.Click(PauseApprenticeshipsLink);

        public SearchHomePage GoToHomePage()
        {
            formCompletionHelper.ClickElement(HomeHeading);
            return new SearchHomePage(_context);
        }

    }
}
