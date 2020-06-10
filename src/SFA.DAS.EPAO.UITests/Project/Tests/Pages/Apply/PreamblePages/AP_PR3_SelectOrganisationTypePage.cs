using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages
{
    public class AP_PR3_SelectOrganisationTypePage : EPAO_BasePage
    {
        protected override string PageTitle => "Select organisation type";
        private readonly ScenarioContext _context;

        #region Locators
        private By AwardingOrg => By.CssSelector("#Awarding_Organisations");
        #endregion

        public AP_PR3_SelectOrganisationTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_PR4_ConfirmOrganisationPage SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(AwardingOrg));
            Continue();
            return new AP_PR4_ConfirmOrganisationPage(_context);
        }
    }
}
