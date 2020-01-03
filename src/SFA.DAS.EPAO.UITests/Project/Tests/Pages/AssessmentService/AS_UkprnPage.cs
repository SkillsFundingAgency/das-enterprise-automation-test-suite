using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_UkprnPage : BasePage
    {
        protected override string PageTitle => "What is the training provider's UK Provider Reference Number (UKPRN)?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _ePAOConfig;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By UkprnTextBox => By.Id("Ukprn");
        #endregion

        public AS_UkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_AchievementDatePage EnterUkprnAndContinue()
        {
            _formCompletionHelper.EnterText(UkprnTextBox, _ePAOConfig.EPAOPrivatelyFundedUkprn);
            Continue();
            return new AS_AchievementDatePage(_context);
        }
    }
}
