using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class NotSureLevyPayingEmployerPage: EmployerBasePage
    {
        protected override string PageTitle => "Funding an apprenticeship for non levy employers";

        public NotSureLevyPayingEmployerPage(ScenarioContext context) : base(context) { }
    }
}