using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class ConfirmPAYESchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm PAYE scheme";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        private readonly ScenarioContext _context;

        public ConfirmPAYESchemePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PAYESchemeAddedPage ClickContinueInConfirmPAYESchemePage()
        {
            Continue();
            return new PAYESchemeAddedPage(_context);
        }
    }
}
