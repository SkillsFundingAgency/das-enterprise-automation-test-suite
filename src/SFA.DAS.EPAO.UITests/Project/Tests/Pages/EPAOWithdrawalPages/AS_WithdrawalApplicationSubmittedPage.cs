using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalApplicationSubmittedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Stage 2 of your application has been submitted";
        private readonly ScenarioContext _context;
        
        #region Locators
        private By StandardNameSubmissionVerification => By.LinkText("Brewer");
        #endregion
        public AS_WithdrawalApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void StandardSubmissionVerification()
        {
            VerifyPage(StandardNameSubmissionVerification, "Brewer");
        }
    }
}