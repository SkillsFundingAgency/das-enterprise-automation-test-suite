using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawalApplicationSubmittedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal notification submitted";
        private readonly ScenarioContext _context;
        
        public AS_WithdrawalApplicationSubmittedPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
        public void StandardSubmissionVerification()
        {
            // Verify reference number?
            VerifyPage();
        }
    }
}