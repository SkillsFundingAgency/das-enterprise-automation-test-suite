using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        private readonly ScenarioContext _context;

        #region Locators
        private By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");
        private By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");
        protected override By ContinueButton => By.CssSelector("input.govuk-button, input.button");
        #endregion

        public SignAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(WantToSignRadioButton);
        }

        public HomePage SignAgreement()
        {
            Sign();
            return new HomePage(_context);
        }

        public HomePage DoNotSignAgreement()
        {
            DoNotSign();
            return new HomePage(_context);
        }

        private void Sign() => Continue(WantToSignRadioButton);

        private void DoNotSign() => Continue(DoNotWantToSignRadioButton);

        private void Continue(By by)
        {
            formCompletionHelper.ClickElement(by);
            formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}