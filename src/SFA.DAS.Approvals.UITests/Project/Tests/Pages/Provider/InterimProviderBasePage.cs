using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ObjectContext objectContext;
        #endregion

        public InterimProviderBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public ProviderHomePage GoToProvideHomePage()
        {
            return new ProviderHomePage(_context, true);
        }

        public ProviderYourCohortsPage GoToProviderYourCohortsPage()
        { 
            return new ProviderYourCohortsPage(_context, true);
        }
    }
}
