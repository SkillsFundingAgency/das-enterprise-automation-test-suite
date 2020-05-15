using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AboutYourAgreementPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "About your agreement";
        private readonly ScenarioContext _context;

        #region Locators
        protected override string Linktext => "Your organisations and agreements";
        protected override By ContinueButton => By.CssSelector("input[value='Continue to your agreement']");
        #endregion

        public AboutYourAgreementPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => _context = context;

        public SignAgreementPage ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
        {
            Continue();
            return new SignAgreementPage(_context);
        }
    }
}