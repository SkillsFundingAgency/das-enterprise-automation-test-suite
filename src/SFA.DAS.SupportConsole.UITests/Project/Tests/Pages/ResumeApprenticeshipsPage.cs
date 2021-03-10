using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ResumeApprenticeshipsPage : ToolSupportBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Resume apprenticeships";

        #region Locators
        private By ResumeApprenticeshipsbtn => By.Id("okButton");
        private By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(11)");
        #endregion

        public ResumeApprenticeshipsPage(ScenarioContext context) : base(context) => _context = context;

        public ResumeApprenticeshipsPage ClickResumeBtn()
        {
            formCompletionHelper.Click(ResumeApprenticeshipsbtn);
            return this;
        }

        public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
    }
}
