using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class SetPermissionsForTrainingProviderPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        protected override string PageTitle => $"Set permissions";
    }
}
