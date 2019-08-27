using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InterimProviderBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
        }

        internal ProviderHomePage GoToProvideHomePage()
        {
            return new ProviderHomePage(_context, true);
        }

        internal ProviderYourCohortsPage GoToProviderYourCohortsPage()
        { 
            return new ProviderYourCohortsPage(_context, true);
        }
    }
}
