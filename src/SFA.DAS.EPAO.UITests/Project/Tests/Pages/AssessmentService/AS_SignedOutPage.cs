using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SignedOutPage : EPAO_BasePage
    {
        protected override string PageTitle => "You have successfully signed out";
        private readonly ScenarioContext _context;

        #region Locators
        private By SignBackInLink => By.XPath("//span[text()='sign back in']");
        #endregion

        public AS_SignedOutPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_LandingPage ClickSignBackInLink()
        {
            formCompletionHelper.Click(SignBackInLink);
            return new AS_LandingPage(_context);
        }
    }
}
