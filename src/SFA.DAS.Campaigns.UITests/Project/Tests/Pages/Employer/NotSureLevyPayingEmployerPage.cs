using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class NotSureLevyPayingEmployerPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Funding an apprenticeship for non levy employers";
    }
}