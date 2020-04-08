using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class EnterTheEmployerDetailsPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Enter the employer details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        private readonly ScenarioContext _context;

        private By EmployerOrganisation(string value = null) => By.CssSelector($"#EmployerOrganisation{value}");

        private By EmployerFirstName(string value = null) => By.CssSelector($"#EmployerFirstName{value}");

        private By EmployerLastName(string value = null) => By.CssSelector($"#EmployerLastName{value}");

        private By EmployerEmailAddress(string value = null) => By.CssSelector($"#EmployerEmailAddress{value}");

        private string LastName => "AutoTester";

        public EnterTheEmployerDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckDetailsPage EnterRegistrationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerOrganisation(), config.RE_OrganisationName);
            formCompletionHelper.EnterText(EmployerFirstName(), config.TwoDigitProjectCode);
            formCompletionHelper.EnterText(EmployerLastName(), LastName);
            formCompletionHelper.EnterText(EmployerEmailAddress(), objectContext.GetRegisteredEmail());
            return NavigateToCheckDetailsPage();
        }

        public EnterTheEmployerDetailsPage VerifyDetails()
        {
            pageInteractionHelper.VerifyPage(EmployerOrganisation($"[value='{config.RE_OrganisationName}']"));
            pageInteractionHelper.VerifyPage(EmployerFirstName($"[value='{config.TwoDigitProjectCode}']"));
            pageInteractionHelper.VerifyPage(EmployerLastName($"[value='{LastName}']"));
            pageInteractionHelper.VerifyPage(EmployerEmailAddress($"[value='{objectContext.GetRegisteredEmail()}']"));
            return this;
        }

        public CheckDetailsPage NavigateToCheckDetailsPage()
        {
            Continue();
            return new CheckDetailsPage(_context);
        }
    }
}