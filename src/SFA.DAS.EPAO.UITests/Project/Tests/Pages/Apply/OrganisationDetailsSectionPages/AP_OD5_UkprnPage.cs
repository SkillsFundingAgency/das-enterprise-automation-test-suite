using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD5_UkprnPage : EPAO_BasePage
    {
        protected override string PageTitle => "Do you have a UK provider registration number (UKPRN)?";
        private readonly ScenarioContext _context;

        #region Locators
        private By UkprnTextbox => By.Id("CD-12.1");
        #endregion

        public AP_OD5_UkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD6_OverallExecutiveMgtPage EnterUkprnAndContinueInDoYouHaveAUkprnPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "CD-12");
            formCompletionHelper.EnterText(UkprnTextbox, dataHelper.GetRandomNumber(8));
            Continue();
            return new AP_OD6_OverallExecutiveMgtPage(_context);
        }
    }
}
