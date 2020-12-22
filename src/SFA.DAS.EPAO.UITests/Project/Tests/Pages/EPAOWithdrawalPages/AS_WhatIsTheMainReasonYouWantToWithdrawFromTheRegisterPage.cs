using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhatIsTheMainReasonYouWantToWithdrawFromTheRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "What's the main reason you want to withdraw from the register?";

        private readonly ScenarioContext _context;
        #region Locators
        //private By AssesmentPlanHasChangedTextArea => By.XPath("(//textarea[@class='govuk-textarea'])[0]");
        private By AssesmentPlanHasChangedTextArea => By.Id("WR-01.1");
        #endregion
        public AS_WhatIsTheMainReasonYouWantToWithdrawFromTheRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WillYouCompleteEPAOForAllRegisteredLearnersPage ClickAssessmentPlanHasChangedAndEnterOptionalReason()
        {
            formCompletionHelper.SelectRadioOptionByText("Assessment plan has changed");
            formCompletionHelper.EnterText(AssesmentPlanHasChangedTextArea, "Assessment plan has changed");
            Continue();
            return new AS_WillYouCompleteEPAOForAllRegisteredLearnersPage(_context);
        }
    }
}
