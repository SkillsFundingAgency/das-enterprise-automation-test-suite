using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD6_OverallExecutiveMgtPage : EPAO_BasePage
    {
        protected override string PageTitle => "Who has responsibility for the overall executive management of your organisation?";
        private readonly ScenarioContext _context;

        #region Locators
        private By FullNameTextbox => By.Id("CD-13");
        private By PostitionDetailsTextbox => By.Id("CD-14.1");
        #endregion

        public AP_OD6_OverallExecutiveMgtPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD7_OfqualRecognitionNumberPage EnterDetailsAndContinueInOEMPage()
        {
            formCompletionHelper.EnterText(FullNameTextbox, dataHelper.GetRandomAlphabeticString(20));
            SelectRadioOptionByForAttribute("CD-14");
            formCompletionHelper.EnterText(PostitionDetailsTextbox, dataHelper.GetRandomAlphabeticString(50));
            Continue();
            return new AP_OD7_OfqualRecognitionNumberPage(_context);
        }
    }
}
