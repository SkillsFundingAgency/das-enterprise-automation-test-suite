using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LandingPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apprenticeship assessment service";
        private readonly ScenarioContext _context;

        #region Locators
        private By StartNowButton => By.LinkText("Start now");
        #endregion

        public AS_LandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_LoginPage ClickStartButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new AS_LoginPage(_context);
        }

        public AS_LandingPage VerifyAS_LandingPage()
        {
            return this;
        }
    }
}
