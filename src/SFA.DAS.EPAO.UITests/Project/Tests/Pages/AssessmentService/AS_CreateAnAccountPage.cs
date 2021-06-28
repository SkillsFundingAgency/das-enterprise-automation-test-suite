using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CreateAnAccountPage : EPAO_BasePage
    {
        protected override string PageTitle => "Create an account";
        private readonly ScenarioContext _context;

        #region Locators
        private By GivenNameTextbox => By.Id("GivenName");
        private By FamilyNameTextbox => By.Id("FamilyName");
        private By EmailAddressTextbox => By.Id("Email");
        #endregion

        public AS_CreateAnAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmYourIdentityPage EnterAccountDetailsAndClickCreateAccount()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, ePAOAssesmentServiceDataHelper.GetRandomAlphabeticString(5));
            formCompletionHelper.EnterText(FamilyNameTextbox, ePAOAssesmentServiceDataHelper.GetRandomAlphabeticString(10));
            formCompletionHelper.EnterText(EmailAddressTextbox, ePAOAssesmentServiceDataHelper.RandomEmail);
            Continue();
            return new AS_ConfirmYourIdentityPage(_context);
        }
    }
}
