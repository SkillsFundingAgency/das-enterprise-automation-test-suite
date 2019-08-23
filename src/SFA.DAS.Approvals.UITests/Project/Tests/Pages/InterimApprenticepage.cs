using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class InterimApprenticepage : InterimBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InterimApprenticepage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
        }
        public ApprenticesHomePage ApprenticesHomePage()
        {
            return new ApprenticesHomePage(_context);
        }

        public ApprenticesHomePage GoToApprenticesHomePage()
        {
            return new ApprenticesHomePage(_context, true);
        }
    }
}

