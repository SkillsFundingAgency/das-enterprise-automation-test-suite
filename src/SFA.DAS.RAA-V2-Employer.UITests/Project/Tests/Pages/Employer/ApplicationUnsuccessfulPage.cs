using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ApplicationUnsuccessfulPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary");

        protected override string PageTitle => "application has been marked as unsuccessful";

        public ApplicationUnsuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
