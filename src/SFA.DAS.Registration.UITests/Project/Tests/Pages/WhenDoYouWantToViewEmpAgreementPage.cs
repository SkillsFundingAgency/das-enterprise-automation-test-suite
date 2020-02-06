using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class WhenDoYouWantToViewEmpAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => "When do you want to view the employer agreement?";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override By ContinueButton => By.Id("submit-when-do-you-want-to-view-button");
        private By ViewItNowRadionButton => By.CssSelector("label");
        #endregion

        public WhenDoYouWantToViewEmpAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SignAgreementPage SelectViewAgreementNowAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ViewItNowRadionButton, "view-it-now");
            Continue();
            return new SignAgreementPage(_context);
        }
    }
}
