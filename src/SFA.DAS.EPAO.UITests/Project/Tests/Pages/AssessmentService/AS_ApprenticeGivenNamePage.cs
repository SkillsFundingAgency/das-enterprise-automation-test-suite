using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ApprenticeGivenNamePage : BasePage
    {
        protected override string PageTitle => "What is the apprentice's given name?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _ePAOConfig;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By GivenNameTextBox => By.Name("FirstName");
        #endregion

        public AS_ApprenticeGivenNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_SearchAndSelectStandard EnterGivenNameAndContinue()
        {
            _formCompletionHelper.EnterText(GivenNameTextBox, _ePAOConfig.EPAOPrivatelyFundedApprenticeGivenName);
            Continue();
            return new AS_SearchAndSelectStandard(_context);
        }
    }
}
