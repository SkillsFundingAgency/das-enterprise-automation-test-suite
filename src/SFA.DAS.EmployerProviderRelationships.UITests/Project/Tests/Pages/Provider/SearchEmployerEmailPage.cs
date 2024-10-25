using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class SearchEmployerEmailPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
    {
        private static By EmailSelector => By.CssSelector("input[id='Email']");

        protected override string PageTitle => "Search employer email";

        public EmailAccountFoundPage EnterEmployerEmail()
        {
            var email = EnterEmail(); 

            return new(context, email);
        }

        public ContactEmployerShutterPage EnterEmployerEmailAndGoToShutterPage()
        {
            EnterEmail();

            return new(context);
        }

        private string EnterEmail()
        {
            var email = eprDataHelper.EmployerEmail;

            formCompletionHelper.EnterText(EmailSelector, email);

            Continue();

            return email;
        }

    }

    public class ContactEmployerShutterPage : ProviderRelationshipsBasePage
    {
        private static By GovBody => By.CssSelector(".govuk-body");

        protected override string PageTitle => "Contact the employer";


        public ContactEmployerShutterPage(ScenarioContext context) : base(context)
        {
            VerifyPage(GovBody, "You cannot add this employer because there are multiple organisations linked to their details.");
        }
    }
}
