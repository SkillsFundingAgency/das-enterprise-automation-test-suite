using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "About your agreement";
        private readonly ScenarioContext _context;

        #region Locators
        private By AgreementButton => By.CssSelector("input.govuk-button");
        protected override string Linktext => "Your organisations and agreements";
        #endregion

        public AboutYourAgreementPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _context = context;

        public SignAgreementPage ContinueWithAgreement()
        {
            Agreement();
            return new SignAgreementPage(_context);
        }

        private AboutYourAgreementPage Agreement()
        {
            formCompletionHelper.ClickElement(AgreementButton);
            return this;
        }
    }
}