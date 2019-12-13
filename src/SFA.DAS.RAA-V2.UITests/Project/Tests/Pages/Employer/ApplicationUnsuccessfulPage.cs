using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ApplicationUnsuccessfulPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary");

        protected override string PageTitle => "application has been marked as unsuccessful";

        public ApplicationUnsuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
