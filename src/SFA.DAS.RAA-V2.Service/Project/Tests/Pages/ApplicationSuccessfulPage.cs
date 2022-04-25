using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ApplicationSuccessfulPage : Raav2BasePage
    {
        protected override By PageHeader => By.CssSelector(".das-notification, .info-summary");

        protected override string PageTitle => "application has been marked as successful";

        public ApplicationSuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
