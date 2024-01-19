using SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding, Scope(Tag = "newuser")]
    public class AfterScenarioHooks(ScenarioContext context)
    {
        private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [AfterScenario(Order = 18)]
        public void DeleteEntities()
        {
            OrganisationListPage GoToOrganisationListPage() => new(context);

            _tryCatch.AfterScenarioException(() =>
            {
                if (_objectContext.IsUserCreated()) new UserPage(context).DeleteUser();

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