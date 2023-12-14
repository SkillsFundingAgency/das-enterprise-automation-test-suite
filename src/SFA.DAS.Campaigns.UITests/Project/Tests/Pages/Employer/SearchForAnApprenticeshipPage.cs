using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SearchForAnApprenticeshipPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Find apprenticeship training";
    }
}

