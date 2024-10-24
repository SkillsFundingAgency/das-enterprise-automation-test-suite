using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class SearchEmployerEmailPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
    {
        private static By EmailSelector => By.CssSelector("input[id='Email']");

        protected override string PageTitle => "Search employer email";

        public EmailAccountFoundPage EmailEmployerEmail(string email)
        {
            formCompletionHelper.EnterText(EmailSelector, email);

            Continue();

            return new(context, email);
        }

    }
}
