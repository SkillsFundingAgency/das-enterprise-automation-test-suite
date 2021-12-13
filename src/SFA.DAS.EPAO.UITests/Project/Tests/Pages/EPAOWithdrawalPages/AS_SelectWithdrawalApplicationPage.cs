using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_SelectWithdrawalApplicationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Select withdrawal application";

        #region Locators
        private By SelectWithdrawalApplicationStartButton => By.LinkText("Start");
        #endregion

        public AS_SelectWithdrawalApplicationPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WhatAreYouWithdrawingFromPage ClickStartSelectWithdrawalApplication()
        {
            formCompletionHelper.ClickElement(SelectWithdrawalApplicationStartButton);
            return new AS_WhatAreYouWithdrawingFromPage(_context);
        }
    }
}
