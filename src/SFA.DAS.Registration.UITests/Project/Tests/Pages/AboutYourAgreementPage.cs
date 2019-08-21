using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : MyAccountWithPaye
    {
        protected override string PageTitle => "About your agreement";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AgreementButton => By.CssSelector("input.button");

        protected override string Linktext => "Your organisations and agreements";


        public AboutYourAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public AboutYourAgreementPage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

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