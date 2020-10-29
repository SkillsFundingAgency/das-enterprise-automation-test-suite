using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding, Scope(Tag = "newuser")]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;

        public AfterScenarioHooks(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 11)]
        public void DeleteEntities()
        {
            var homePage = new HomePage(_context, true);

            var userpage = homePage.NavigateToAdminPage().NavigateToUserPage();

            userpage.DeleteEntity(true);

            userpage.DeleteEntity();
        }
    }
}