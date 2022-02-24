using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding, Scope(Tag = "newuser")]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly TryCatchExceptionHelper _tryCatch;
        private readonly ObjectContext _objectContext;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [AfterScenario(Order = 18)]
        public void DeleteEntities()
        {
            AdminPage NavigateToAdminPage() => new HomePage(_context, true).NavigateToAdminPage();

            _tryCatch.AfterScenarioException(() => 
            {
                if (_objectContext.IsUserCreated()) NavigateToAdminPage().NavigateToUserPage().DeleteUser();
                
                if (!(_objectContext.IsOrgCreated())) return;

                var adminPage = NavigateToAdminPage();

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