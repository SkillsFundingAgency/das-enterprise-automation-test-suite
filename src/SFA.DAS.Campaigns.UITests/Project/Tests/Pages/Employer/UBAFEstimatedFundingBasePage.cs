using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class UBAFEstimatedFundingBasePage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Understanding apprenticeship benefits and funding";

    }
}
