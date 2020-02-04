using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SignedOutPage : EPAO_BasePage
    {
        protected override string PageTitle => "Signed out";
        private readonly ScenarioContext _context;

        #region Locators
        private By AssessmentServiceLink => By.XPath("//span[text()='Apprenticeship assessment service']");
        #endregion

        public AS_SignedOutPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_LandingPage ClickReturnToAssessmentServiceLink()
        {
            formCompletionHelper.Click(AssessmentServiceLink);
            return new AS_LandingPage(_context);
        }
    }
}
