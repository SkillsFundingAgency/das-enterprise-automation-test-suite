using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_PhoneNumberVerificationPage : FAABasePage
    {
        protected override string PageTitle => "Verify your mobile number";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EnterCode => By.Id("VerifyMobileCode");
        private By VerifyNumber => By.Id("verify-code-button");

        public FAA_PhoneNumberVerificationPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            // this is temp work aound as the redirection is not working correctly.
            VerifyPage(() =>
            {
                var uri = new Uri(new Uri(faaConfig.FAA_BaseUrl), $"verifymobile");
                tabHelper.GoToUrl(uri.AbsoluteUri);
                return pageInteractionHelper.FindElements(PageHeader);
            }, PageTitle);
        }

        public FAA_SettingsPage EnterVerificationCode()
        {            
            formCompletionHelper.EnterText(EnterCode, faaDataHelper.PhoneNumberVerificationCode);
            formCompletionHelper.Click(VerifyNumber);
            pageInteractionHelper.WaitforURLToChange("settings");
            return new FAA_SettingsPage(_context);
        }
    }
}
