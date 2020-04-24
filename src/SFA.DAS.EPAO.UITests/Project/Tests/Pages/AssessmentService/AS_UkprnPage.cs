using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_UkprnPage : EPAO_BasePage
    {
        protected override string PageTitle => "What is the training provider's UK Provider Reference Number (UKPRN)?";
        private readonly ScenarioContext _context;

        #region Locators
        private By UkprnTextBox => By.Id("Ukprn");
        #endregion

        public AS_UkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_AchievementDatePage EnterUkprnAndContinue()
        {
            formCompletionHelper.EnterText(UkprnTextBox, ePAOConfig.PrivatelyFundedUkprn);
            Continue();
            return new AS_AchievementDatePage(_context);
        }
    }
}
