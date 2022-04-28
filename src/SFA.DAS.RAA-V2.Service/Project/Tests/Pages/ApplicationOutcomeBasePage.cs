using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class ApplicationOutcomeBasePage : Raav2BasePage
    {
        protected override By PageHeader => By.CssSelector(".das-notification, .info-summary");

        protected override string PageTitle => $"application has been marked as {_message}";

        private readonly string _message;

        public ApplicationOutcomeBasePage(ScenarioContext context, string message) : base(context, false) 
        {
            _message = message;

            VerifyPage();
        }
    }
}
