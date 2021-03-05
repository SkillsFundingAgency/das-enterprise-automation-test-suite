using NUnit.Framework;
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
        private By DateInputBox => By.Id("date_0");
        private By SetBtn => By.Id("btnSetBulkDate");
        private By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(12)");
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

        public StopApprenticeshipsPage EnterStopDateAndClickSetbutton()
        {
            string stopDate = "01/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString("0000");
            pageInteractionHelper.WaitForElementToBeClickable(StopDate);
            formCompletionHelper.EnterText(StopDate, stopDate);
            formCompletionHelper.Click(SetBtn);
            return this;
        }

        public StopApprenticeshipsPage ValidateStopDateApplied()
        {
            var actualDate = pageInteractionHelper.FindElement(DateInputBox).GetAttribute("value");
            string expectedDate = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-01";
            Assert.AreEqual(expectedDate, actualDate, "Validate correct stop date has been set in the table");
            return this;
        }
    }
}
