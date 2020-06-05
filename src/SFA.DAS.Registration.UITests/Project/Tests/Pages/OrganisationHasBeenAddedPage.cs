using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class OrganisationHasBeenAddedPage : InterimHomeBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName() + " has been added";

        protected override By PageHeader => By.CssSelector("h1");

        public OrganisationHasBeenAddedPage(ScenarioContext context) : base(context, false) { }
    }
}
