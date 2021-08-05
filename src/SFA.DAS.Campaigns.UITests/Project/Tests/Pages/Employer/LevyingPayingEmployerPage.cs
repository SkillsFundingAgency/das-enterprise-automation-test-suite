using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class LevyingPayingEmployerPage: EmployerBasePage
    {
        protected override string PageTitle => "Funding an apprenticeship for levy payers";

        public LevyingPayingEmployerPage(ScenarioContext context) : base(context) { }
    }
}