using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_SelectWithdrawalApplicationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Select withdrawal application";
        private readonly ScenarioContext _context;

        #region Locators
        private By SelectWithdrawalApplicationStartButton => By.LinkText("Start");
        #endregion
        public AS_SelectWithdrawalApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatAreYouWithdrawingFromPage ClickStartSelectWithdrawalApplication()
        {
            formCompletionHelper.ClickElement(SelectWithdrawalApplicationStartButton);
            return new AS_WhatAreYouWithdrawingFromPage(_context);
        }
    }
}
