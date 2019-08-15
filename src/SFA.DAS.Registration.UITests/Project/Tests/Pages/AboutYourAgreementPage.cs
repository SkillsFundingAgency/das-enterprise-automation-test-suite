using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : MyAccountWithPaye
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AgreementButton => By.CssSelector("input.button");

        protected override string PageTitle => "About your agreement";

        protected override string Linktext => "Your organisations and agreements";


        public AboutYourAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public AboutYourAgreementPage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

        public SignAgreementPage Agreement()
        {
            ContinueWithAgreement();
            return new SignAgreementPage(_context);
        }

        private void ContinueWithAgreement()
        {
            formCompletionHelper.ClickElement(AgreementButton);
        }
    }
}