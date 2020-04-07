using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class EnterTheEmployerDetailsPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Enter the employer details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        private readonly ScenarioContext _context;

        private By EmployerOrganisation => By.CssSelector("#EmployerOrganisation");

        private By EmployerFirstName => By.CssSelector("#EmployerFirstName");

        private By EmployerLastName => By.CssSelector("#EmployerLastName");

        private By EmployerEmailAddress => By.CssSelector("#EmployerEmailAddress");

        private string LastName => "AutoTester";

        public EnterTheEmployerDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckDetailsPage EnterRegistrationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerOrganisation, config.RE_OrganisationName);
            formCompletionHelper.EnterText(EmployerFirstName, config.TwoDigitProjectCode);
            formCompletionHelper.EnterText(EmployerLastName, LastName);
            formCompletionHelper.EnterText(EmployerEmailAddress, objectContext.GetRegisteredEmail());
            return NavigateToCheckDetailsPage();
        }

        public EnterTheEmployerDetailsPage VerifyDetails()
        {
            pageInteractionHelper.VerifyText(EmployerOrganisation, config.RE_OrganisationName);
            pageInteractionHelper.VerifyText(EmployerFirstName, config.TwoDigitProjectCode);
            pageInteractionHelper.VerifyText(EmployerLastName, LastName);
            pageInteractionHelper.VerifyText(EmployerEmailAddress, objectContext.GetRegisteredEmail());
            return this;
        }

        public CheckDetailsPage NavigateToCheckDetailsPage()
        {
            Continue();
            return new CheckDetailsPage(_context);
        }
    }
}