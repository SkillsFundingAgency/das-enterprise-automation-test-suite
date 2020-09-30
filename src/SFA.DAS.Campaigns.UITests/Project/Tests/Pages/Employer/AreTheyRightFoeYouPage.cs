using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class AreTheyRightFoeYouPage: EmployerBasePage
    {
        protected override string PageTitle => "Are they right for you?";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public AreTheyRightFoeYouPage(ScenarioContext context):base(context) { }
    }
}