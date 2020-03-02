using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_PhoneNumberVerificationPage : BasePage
    {
        protected override string PageTitle => "Verify your mobile number";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly FAADataHelper _dataHelper;
        #endregion

        private By EnterCode = By.Id("VerifyMobileCode");
        private By VerifyNumber = By.Id("verify-code-button");
        public FAA_PhoneNumberVerificationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>(); 
            _dataHelper = context.Get<FAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public FAA_SettingsPage EnterVerificationCode()
        {            
            _formCompletionHelper.EnterText(EnterCode, _dataHelper.PhoneNumberVerificationCode);
            _formCompletionHelper.Click(VerifyNumber);
            return new FAA_SettingsPage(_context);
        }
    }
}
