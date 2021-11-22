using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class ConfirmOptInForAssociateProjectManagerPage : EPAO_BasePage
    {
        protected override string PageTitle => "Associate project manager";

        private readonly ScenarioContext _context;

        public ConfirmOptInForAssociateProjectManagerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OptInConfirmationPage ConfirmOptIn()
        {
            Continue();
            return new OptInConfirmationPage(_context);
        }
    }
}