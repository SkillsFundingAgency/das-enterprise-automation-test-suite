using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ApprenticeGivenNamePage : EPAO_BasePage
    {
        protected override string PageTitle => "What is the apprentice's given name?";
        private readonly ScenarioContext _context;

        #region Locators
        private By GivenNameTextBox => By.Name("FirstName");
        #endregion

        public AS_ApprenticeGivenNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_SearchAndSelectStandardPage EnterGivenNameAndContinue()
        {
            formCompletionHelper.EnterText(GivenNameTextBox, ePAOConfig.EPAOPrivatelyFundedApprenticeGivenName);
            Continue();
            return new AS_SearchAndSelectStandardPage(_context);
        }
    }
}
