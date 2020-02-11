using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangePhoneNumberPage : EPAO_BasePage
    {
        protected override string PageTitle => "Change phone number";
        private readonly ScenarioContext _context;

        #region Locators
        private By PhoneNumberTextBox => By.CssSelector(".govuk-input");
        #endregion

        public AS_ChangePhoneNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmPhoneNumberPage EnterRandomPhoneNumberAndClickUpdate()
        {
            formCompletionHelper.EnterText(PhoneNumberTextBox, dataHelper.GetRandomNumber(10));
            Continue();
            return new AS_ConfirmPhoneNumberPage(_context);
        }
    }

    public class AS_ConfirmPhoneNumberPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm phone number";
        private readonly ScenarioContext _context;

        public AS_ConfirmPhoneNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ContactPhoneNumberUpdatedPage ClickConfirmButtonInConfirmPhoneNumberPage()
        {
            Continue();
            return new AS_ContactPhoneNumberUpdatedPage(_context);
        }
    }

    public class AS_ContactPhoneNumberUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Contact phone number updated";

        public AS_ContactPhoneNumberUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
