using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SearchForAnApprenticeshipPage : EmployerHubPage
    {
        protected override string PageTitle => "Find apprenticeship training";

        public SearchForAnApprenticeshipPage(ScenarioContext context) : base(context) { }
    }
}

