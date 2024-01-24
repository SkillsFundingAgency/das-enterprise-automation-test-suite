using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SetUpServicePage(ScenarioContext context) : ApprenticeBasePage(context)
    {
        protected override string PageTitle => "Create an account to search and apply for apprenticeships";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
    }
}