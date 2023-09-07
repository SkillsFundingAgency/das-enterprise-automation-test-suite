using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AppliationApprovedPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Application approved";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        public AppliationApprovedPage(ScenarioContext context) : base(context) { }

        public TransferPledgePage ClickBackButton()
        {
            NavigateBack();
            return new TransferPledgePage(context);
        }
    }
}