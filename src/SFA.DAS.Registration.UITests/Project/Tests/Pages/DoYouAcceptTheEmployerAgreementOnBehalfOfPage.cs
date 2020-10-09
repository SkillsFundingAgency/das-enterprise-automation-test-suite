using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DoYouAcceptTheEmployerAgreementOnBehalfOfPage : RegistrationBasePage
    {
        protected override string PageTitle => "Do you accept the employer agreement on behalf of";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.XPath("//input[@class='govuk-button govuk-!-margin-top-6']");
        #endregion

        public DoYouAcceptTheEmployerAgreementOnBehalfOfPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public AccessDeniedPage ClickYesAndContinueDoYouAcceptTheEmployerAgreementOnBehalfOfPage()
        {
            SelectRadioOptionByText("Yes, I accept the agreement");
            formCompletionHelper.Click(ContinueButton);
            return new AccessDeniedPage (_context);
        }
    }
}