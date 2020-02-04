using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD7_OfqualRecognitionNumberPage : EPAO_BasePage
    {
        protected override string PageTitle => "Do you have an Ofqual recognition number?";
        private readonly ScenarioContext _context;

        #region Locators
        private By OfqualRecognitionNumberTextbox => By.Id("CD-15.1");
        #endregion

        public AP_OD7_OfqualRecognitionNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD8_TradingStatusPage EnterDetailsAndContinueInOfqualRecognitionNumberPage()
        {
            SelectRadioOptionByForAttribute("CD-15");
            formCompletionHelper.EnterText(OfqualRecognitionNumberTextbox, dataHelper.GetRandomNumber(6));
            Continue();
            return new AP_OD8_TradingStatusPage(_context);
        }
    }
}
