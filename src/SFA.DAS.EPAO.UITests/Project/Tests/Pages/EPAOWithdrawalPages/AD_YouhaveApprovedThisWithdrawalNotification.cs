using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_YouhaveApprovedThisWithdrawalNotification : EPAO_BasePage
    {
        protected override string PageTitle => "You've approved this withdrawal notification";
       
        private readonly ScenarioContext _context;

        private By ReturnToApprovedWithdrawals => By.CssSelector("a[href='/WithdrawalApplication/WithdrawalApplications#approved']");

        private By WithdrawlFromRegisterApprovedMessage => By.XPath("//p[contains(text(), \"You've approved this organisation to withdraw from the register of end-point assessment organisations.\")]");
        
        public AD_YouhaveApprovedThisWithdrawalNotification(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AD_YouhaveApprovedThisWithdrawalNotification VerifyRegisterWithdrawalBodyText()
        {
            Assert.IsNotNull(pageInteractionHelper.FindElement(WithdrawlFromRegisterApprovedMessage));
            return this;
        }

        public AD_WithdrawalApplicationsPage ReturnToWithdrawalApplications()
        {
            formCompletionHelper.ClickElement(ReturnToApprovedWithdrawals);
            return new AD_WithdrawalApplicationsPage(_context);
        }
    }
}
