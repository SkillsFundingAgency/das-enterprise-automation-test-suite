using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class GettingStartedPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Get started";

        public GettingStartedPage(ScenarioContext context): base(context) { }
    }
}