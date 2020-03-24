using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeEmailPage : EPAO_BasePage
    {
        protected override string PageTitle => "Change email address";
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailTextBox => By.Id("Email");
        #endregion

        public AS_ChangeEmailPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmEmailAddressPage EnterRandomEmailAndClickChange()
        {
            formCompletionHelper.EnterText(EmailTextBox, dataHelper.RandomEmail);
            Continue();
            return new AS_ConfirmEmailAddressPage(_context);
        }
    }

    public class AS_ConfirmEmailAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm email address";
        private readonly ScenarioContext _context;

        public AS_ConfirmEmailAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_EmailAddressUpdatedPage ClickConfirmButtonInConfirmEmailAddressPage()
        {
            Continue();
            return new AS_EmailAddressUpdatedPage(_context);
        }
    }

    public class AS_EmailAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Email address updated";

        public AS_EmailAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}