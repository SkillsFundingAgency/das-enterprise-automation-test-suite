using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ApprovalsConfig config;
        #endregion

        public InterimProviderBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            config = context.GetApprovalsConfig<ApprovalsConfig>();
            VerifyPage();
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
