using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_MyApplicationsPage(ScenarioContext context) : Manage_HeaderSectionBasePage(context)
    {
        protected override string PageTitle => "My applications";
    }
}
