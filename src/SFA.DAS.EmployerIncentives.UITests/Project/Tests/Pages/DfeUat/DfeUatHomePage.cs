using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class DfeUatHomePage : EIBasePage
    {
        protected override string PageTitle => "Department for Education";

        protected override By PageHeader => By.CssSelector("#homepageContent");

        public DfeUatHomePage(ScenarioContext context) : base(context) { }
    }
}
