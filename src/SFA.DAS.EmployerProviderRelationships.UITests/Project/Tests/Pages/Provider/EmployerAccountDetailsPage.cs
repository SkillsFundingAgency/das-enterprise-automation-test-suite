using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class EmployerAccountDetailsPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
    {
        protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

        protected override string PageTitle => "Employer account details";

        public void ChangePermissions()
        {
            Continue();
        }

    }
}
