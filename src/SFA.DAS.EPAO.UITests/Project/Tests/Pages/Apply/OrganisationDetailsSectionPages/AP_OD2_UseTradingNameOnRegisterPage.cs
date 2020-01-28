using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD2_UseTradingNameOnRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "Do you want to use your trading name on the register?";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesRadioButton => By.Id("CD-01");
        #endregion

        public AP_OD2_UseTradingNameOnRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD3_ContactDetailsPage SelectYesAndContinueInUseYourTradingNameOnTheRegisterPage()
        {
            formCompletionHelper.SelectRadioButton(pageInteractionHelper.FindElement(YesRadioButton));
            Continue();
            return new AP_OD3_ContactDetailsPage(_context);
        }
    }
}
