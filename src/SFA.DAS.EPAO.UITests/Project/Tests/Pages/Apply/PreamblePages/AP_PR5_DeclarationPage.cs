using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages
{
    public class AP_PR5_DeclarationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Declaration";
        private readonly ScenarioContext _context;

        public AP_PR5_DeclarationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_ApplicationOverviewPage ClickAcceptAndContinueInDeclarationPage()
        {
            Continue();
            return new AP_ApplicationOverviewPage(_context);
        }
    }
}
