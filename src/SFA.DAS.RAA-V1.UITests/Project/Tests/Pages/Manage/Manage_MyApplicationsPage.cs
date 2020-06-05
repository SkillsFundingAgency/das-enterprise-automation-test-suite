using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_MyApplicationsPage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "My applications";

        public Manage_MyApplicationsPage(ScenarioContext context) : base(context)
        {

        }
    }
}
