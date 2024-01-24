using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class OrganisationHasBeenAddedPage(ScenarioContext context) : InterimHomeBasePage(context, false)
    {
        protected override string PageTitle => objectContext.GetRecentlyAddedOrganisationName() + " has been added";

        protected override string AccessibilityPageTitle => "Organisation has been added page";

        protected override By PageHeader => By.CssSelector(".das-notification__heading");
    }
}
