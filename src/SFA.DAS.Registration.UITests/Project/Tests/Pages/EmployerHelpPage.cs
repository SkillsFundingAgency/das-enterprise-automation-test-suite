using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmployerHelpPage : RegistrationBasePage
    {
        protected override string PageTitle { get; }

        protected override By PageHeader => By.CssSelector("body");

        protected override bool CanAnalyzePage => false;

        public EmployerHelpPage(ScenarioContext context) : base(context) => VerifyPage(PageHeader);
    }
}