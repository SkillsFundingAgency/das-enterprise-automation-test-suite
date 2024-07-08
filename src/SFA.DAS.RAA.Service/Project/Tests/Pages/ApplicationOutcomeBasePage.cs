using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ApplicationOutcomeBasePage : RaaBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-notification-banner__heading");

        protected override string PageTitle => $"application has been marked as {_message}";

        private readonly string _message;

        public ApplicationOutcomeBasePage(ScenarioContext context, string message) : base(context, false)
        {
            _message = message;

            VerifyPage();
        }
    }
}
