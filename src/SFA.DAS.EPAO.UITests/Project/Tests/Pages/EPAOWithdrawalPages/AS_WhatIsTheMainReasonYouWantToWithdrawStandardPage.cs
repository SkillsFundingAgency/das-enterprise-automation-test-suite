using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "What's the main reason you want to withdraw from assessing this standard?";
        private readonly ScenarioContext _context;
        #region Locators
        private By ExternalQualityAssuranceProviderHasChanged => By.XPath("//*[contains(text(),'External quality assurance provider has changed')]");
        private By ExternalQualityAssuranceProviderHasChangedTextArea => By.XPath("(//div[@class='govuk-form-group'])[6]");
        #endregion
        public AS_WhatIsTheMainReasonYouWantToWithdrawStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public AS_WillYouCompleteEPAOForAllRegisteredLearnersPage ClickExternalQualityAssuranceProviderHasChanged()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ExternalQualityAssuranceProviderHasChanged);
            Continue();
            return new AS_WillYouCompleteEPAOForAllRegisteredLearnersPage (_context);
        }
    }
}