using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApplicationSubmittedPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Your application has been submitted";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        public ApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }
}