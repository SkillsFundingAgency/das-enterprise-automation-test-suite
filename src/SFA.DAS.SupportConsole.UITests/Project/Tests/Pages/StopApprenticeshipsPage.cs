using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class StopApprenticeshipsPage : ToolSupportBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Stop apprenticeships";

        #region Locators
        private By StopApprenticeshipsbtn => By.Id("okButton");
        private By StopDate => By.Id("bulkDate");
        private By SetBtn => By.Id("btnSetBulkDate");
        private By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(10)");
        private By ErrorMessage => By.XPath("//li[contains(text(),'Not all Apprenticeship rows have been supplied wit')]");
        #endregion

        public StopApprenticeshipsPage(ScenarioContext context) : base(context) => _context = context;

        public StopApprenticeshipsPage ClickStopBtn()
        {
            formCompletionHelper.Click(StopApprenticeshipsbtn);
            return this;
        }

        public StopApprenticeshipsPage ValidateErrorMessage()
        {
            pageInteractionHelper.IsElementDisplayed(ErrorMessage);
            return this;
        }

        public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);

        public StopApprenticeshipsPage EnterStopDate()
        {
            string stopDate = $"01//{DateTime.Now.Month}//{DateTime.Now.Year}";
            formCompletionHelper.EnterText(StopDate, stopDate);
            return this;
        }

        public StopApprenticeshipsPage ClickSetButton()
        {
            formCompletionHelper.Click(SetBtn);
            return this;
        }


    }
}
