using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD3_SelectOrganisationTypePage : EPAO_BasePage
    {
        protected override string PageTitle => "Select organisation type";
        private readonly ScenarioContext _context;

        #region Locators
        private By TrainingProviderRadioButton => By.Id("Training_Provider");
        #endregion

        public AP_OD3_SelectOrganisationTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD4_ConfirmOrganisationPage SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
        {
            formCompletionHelper.Click(TrainingProviderRadioButton);
            Continue();
            return new AP_OD4_ConfirmOrganisationPage(_context);
        }
    }
}
