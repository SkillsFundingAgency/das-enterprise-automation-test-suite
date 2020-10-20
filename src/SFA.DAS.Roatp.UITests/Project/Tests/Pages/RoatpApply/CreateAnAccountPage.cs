using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class CreateAnAccountPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Create an account";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        #region Locators
        private By GivenNameTextbox => By.Id("GivenName");
        private By FamilyNameTextbox => By.Id("FamilyName");
        private By EmailAddressTextbox => By.Id("Email");
        #endregion

        public CreateAnAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmYourIdentityPage EnterAccountDetailsAndClickCreateAccount()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, applydataHelpers.GivenName);
            formCompletionHelper.EnterText(FamilyNameTextbox, applydataHelpers.FamilyName);
            formCompletionHelper.EnterText(EmailAddressTextbox, applydataHelpers.CreateAccountEmail);
            Continue();
            return new ConfirmYourIdentityPage(_context);
        }
    }
}
