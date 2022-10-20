using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class EmployerAccountIsReadyPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Invitation sent to employer";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        public EmployerAccountIsReadyPage(ScenarioContext context) : base(context) { }
    }
}