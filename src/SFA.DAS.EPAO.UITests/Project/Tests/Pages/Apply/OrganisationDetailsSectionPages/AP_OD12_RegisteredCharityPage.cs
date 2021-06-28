using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD_12_RegisteredCharityPage : EPAO_BasePage
    {
        protected override string PageTitle => "Is your organisation a registered charity?";
        private readonly ScenarioContext _context;

        #region Locators
        private By CharityNumberTextbox => By.Id("CD-26.1");
        #endregion

        public AP_OD_12_RegisteredCharityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD13_RegisterOfRemovedTrusteesPage EnterCharityDetailsAndContinueInRegisteredCharityPage()
        {
            SelectRadioOptionByForAttribute("CD-26");
            formCompletionHelper.EnterText(CharityNumberTextbox, ePAOApplyDataHelper.GetRandomNumber(8));
            Continue();
            return new AP_OD13_RegisterOfRemovedTrusteesPage(_context);
        }
    }
}
