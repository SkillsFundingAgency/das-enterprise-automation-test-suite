using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class PauseApprenticeshipsPage : ToolSupportBasePage       
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Pause apprenticeships";

        #region Locators
        private By PauseApprenticeshipsbtn => By.Id("okButton");
        private By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(11)");
        #endregion

        public PauseApprenticeshipsPage(ScenarioContext context) : base(context) => _context = context;

        public PauseApprenticeshipsPage ClickPauseBtn()
        {
            formCompletionHelper.Click(PauseApprenticeshipsbtn);
            return this;
        }

        public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);

    }
}
