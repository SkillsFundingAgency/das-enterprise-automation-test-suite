using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class LevyingPayingEmployerPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Funding an apprenticeship for levy payers";
    }
}