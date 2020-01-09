using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LandingPage : BasePage
    {
        protected override string PageTitle => "Apprenticeship assessment service";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By StartNowButton => By.LinkText("Start now");
        #endregion

        public AS_LandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_LoginPage ClickStartButton()
        {
            _formCompletionHelper.Click(StartNowButton);
            return new AS_LoginPage(_context);
        }

        public AS_LandingPage VerifyAS_LandingPage()
        {
            return this;
        }
    }
}
