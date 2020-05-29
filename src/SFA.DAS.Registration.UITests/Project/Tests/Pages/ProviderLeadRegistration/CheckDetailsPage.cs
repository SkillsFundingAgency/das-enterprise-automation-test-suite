using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class CheckDetailsPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Check details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        private readonly ScenarioContext _context;

        private By ChangeDetailsLink => By.CssSelector(".govuk-link[type='submit'][value='Change']");

        public CheckDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerAccountIsReadyPage InviteEmployer()
        {
            Continue();
            return new EmployerAccountIsReadyPage(_context);
        }

        public EnterTheEmployerDetailsPage ChangeDetails()
        {
            formCompletionHelper.ClickElement(ChangeDetailsLink);
            return new EnterTheEmployerDetailsPage(_context);
        }
    }
}