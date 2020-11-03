using SFA.DAS.ConfigurationBuilder;
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
            _tryCatch.AfterScenarioException(() => 
            {
                var homePage = new HomePage(_context, true);

                var userpage = homePage.NavigateToAdminPage().NavigateToUserPage();

                userpage.DeleteEntity(true);

                userpage.DeleteEntity();
            });
        }
    }
}