using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class EmailAccountFoundPage : ProviderRelationshipsBasePage
    {
        protected override By ContinueButton => By.CssSelector("a.govuk-button[href*='addEmployer']");

        private static By GovBody => By.CssSelector(".govuk-body");

        protected override string PageTitle => "Account found";

        public EmailAccountFoundPage(ScenarioContext context, string email) : base(context)
        {
            VerifyPage(GovBody, email);
        }

        public ProviderRequestPermissionsPage ContinueToInvite()
        {
            Continue();

            return new(context);
        }
    }
}
