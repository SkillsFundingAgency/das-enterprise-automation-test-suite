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

        private readonly string OrganisationName;
        private readonly string FirstName;
        private readonly string LastName;
        private readonly string Email;

        public EnterTheEmployerDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            OrganisationName = config.RE_OrganisationName;
            FirstName = registrationDataHelper.FirstName;
            LastName = registrationDataHelper.LastName;
            Email = objectContext.GetRegisteredEmail();
        }

        public CheckDetailsPage EnterRegistrationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerOrganisation(), OrganisationName);
            formCompletionHelper.EnterText(EmployerFirstName(), FirstName);
            formCompletionHelper.EnterText(EmployerLastName(), LastName);
            formCompletionHelper.EnterText(EmployerEmailAddress(), Email);
            return NavigateToCheckDetailsPage();
        }

        public EnterTheEmployerDetailsPage VerifyDetails()
        {
            pageInteractionHelper.VerifyPage(EmployerOrganisation($"[value='{OrganisationName}']"));
            pageInteractionHelper.VerifyPage(EmployerFirstName($"[value='{FirstName}']"));
            pageInteractionHelper.VerifyPage(EmployerLastName($"[value='{LastName}']"));
            pageInteractionHelper.VerifyPage(EmployerEmailAddress($"[value='{Email}']"));
            return this;
        }

        public CheckDetailsPage NavigateToCheckDetailsPage()
        {
            Continue();
            return new CheckDetailsPage(_context);
        }
    }
}