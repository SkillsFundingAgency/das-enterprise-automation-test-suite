using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD1_TradingNamePage : EPAO_BasePage
    {
        protected override string PageTitle => "Does your organisation have a trading name?";
        private readonly ScenarioContext _context;

        #region Locators
        private By TradingNameTextbox => By.Id("CD-30.1");
        #endregion

        public AP_OD1_TradingNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD2_UseTradingNameOnRegisterPage GiveATradingNameAndContinueInTradingNamePage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "CD-30");
            formCompletionHelper.EnterText(TradingNameTextbox, dataHelper.GetRandomAlphabeticString(10));
            Continue();
            return new AP_OD2_UseTradingNameOnRegisterPage(_context);
        }
    }
}
