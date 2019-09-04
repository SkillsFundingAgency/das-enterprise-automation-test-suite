using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        public ProviderPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
        }

        public bool IsSignInPageDisplayed()
        {
            return new CheckProviderSignInPage(_context)
                .IsPageDisplayed();
        }

        public bool IsIndexPageDisplayed()
        {
            return new CheckProviderIndexPage(_context)
                    .IsPageDisplayed();
        }

        public void ReLogin()
        {
            new ProviderSiginPage(_context)
                    .SubmitValidLoginDetails();
        }
    }
}
