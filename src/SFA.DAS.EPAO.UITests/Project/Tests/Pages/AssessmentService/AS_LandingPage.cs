using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_LandingPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apprenticeship assessment service";
        private readonly ScenarioContext _context;

        #region Locators
        private By StartNowButton => By.LinkText("Start now");
        private By CreateAnAccountLink => By.XPath("//a[@href='/Account/CreateAnAccount']");
        #endregion

        public AS_LandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            AcceptCookies();
        }

        public AS_LoginPage ClickStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new AS_LoginPage(_context);
        }

        public AS_ApplyForAStandardPage AlreadyLoginClickStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new AS_ApplyForAStandardPage(_context);
        }

        public AS_CreateAnAccountPage ClickCreateAnAccountLink()
        {
            formCompletionHelper.Click(CreateAnAccountLink);
            return new AS_CreateAnAccountPage(_context);
        }

        public AS_LoggedInHomePage WithdrawalAlreadyLoginClickStartNowButton()
        {
            formCompletionHelper.Click(StartNowButton);
            return new AS_LoggedInHomePage(_context);
        }
    }
}
