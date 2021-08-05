using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SettingItUpPage : EmployerBasePage
    {
        protected override string PageTitle => "Setting it up";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public SettingItUpPage(ScenarioContext context) : base(context) { }
    }
}