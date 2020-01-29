using FluentAssertions;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SettingsPage : BasePage
    {
        protected override string PageTitle => "Settings";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;     
        private readonly FAADataHelper _dataHelper;
        #endregion

        private By SuccessfulMobileVerificationText => By.Id("SuccessMessageText");

        public FAA_SettingsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();            
            _dataHelper = context.Get<FAADataHelper>();
            VerifyPage();
        }

        public void VerifySuccessfulVerificationText()
        {
            string  messageText = _pageInteractionHelper.GetText(SuccessfulMobileVerificationText);
            messageText.Should().Contain(_dataHelper.SuccessfulPhoneVerificationText);
        }


    }
}
