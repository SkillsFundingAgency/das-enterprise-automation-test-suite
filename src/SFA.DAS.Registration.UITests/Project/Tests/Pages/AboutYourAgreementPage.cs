using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : InterimBasePage
    {
        protected override string PageTitle => "About your agreement";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AgreementButton => By.CssSelector("input.button");

        private By TransferStatus => By.ClassName("transfers-status");

        protected override string Linktext => "Your organisations and agreements";

        public AboutYourAgreementPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
        }

        public SignAgreementPage ContinueWithAgreement()
        {
            Agreement();
            return new SignAgreementPage(_context);
        }

        public string GetTransfersStatus()
        {
            return pageInteractionHelper.GetText(TransferStatus);
        }

        private AboutYourAgreementPage Agreement()
        {
            formCompletionHelper.ClickElement(AgreementButton);
            return this;
        }
    }
}