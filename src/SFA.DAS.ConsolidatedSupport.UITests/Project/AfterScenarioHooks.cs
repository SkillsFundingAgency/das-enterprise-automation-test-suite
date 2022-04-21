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

            OrganisationListPage GoToOrganisationListPage() => new OrganisationListPage(_context);

            _tryCatch.AfterScenarioException(() => 
            {
                if (_objectContext.IsUserCreated()) new UserPage(_context).DeleteUser();

                if (!(_objectContext.IsOrgCreated())) return;

                var OrgListPage = GoToOrganisationListPage();

                var orgCount = OrgListPage.NoOfOrganisation();

                for (int i = 0; i < orgCount; i++)
                {
                    OrgListPage.NavigateToOrgPage().DeleteOrg();

                    OrgListPage = GoToOrganisationListPage();
                }
            });
        }
    }
}