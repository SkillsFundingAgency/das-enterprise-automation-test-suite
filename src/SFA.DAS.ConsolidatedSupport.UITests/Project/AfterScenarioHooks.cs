using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding, Scope(Tag = "newuser")]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly TryCatchExceptionHelper _tryCatch;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [AfterScenario(Order = 18)]
        public void DeleteEntities()
        {
            AdminPage NavigateToAdminPage() => new HomePage(_context, true).NavigateToAdminPage();

            _tryCatch.AfterScenarioException(() => 
            {
                var adminPage = NavigateToAdminPage();

                adminPage.NavigateToUserPage().DeleteUser();

                adminPage = NavigateToAdminPage();

                var orgCount = adminPage.NoOfOrganisation();

                for (int i = 0; i < orgCount; i++)
                {
                    var orgpage = adminPage.NavigateToOrgPage();

                    orgpage.DeleteOrg();

                    adminPage = NavigateToAdminPage();
                }
            });
        }
    }
}