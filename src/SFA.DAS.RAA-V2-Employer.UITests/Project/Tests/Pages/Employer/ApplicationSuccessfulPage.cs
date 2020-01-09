using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ApplicationSuccessfulPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary");

        protected override string PageTitle => "application has been marked as successful";

        public ApplicationSuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
