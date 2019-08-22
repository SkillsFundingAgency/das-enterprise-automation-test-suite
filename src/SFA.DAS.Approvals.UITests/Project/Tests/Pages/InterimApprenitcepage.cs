using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public abstract class InterimApprenitcepage : InterimBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InterimApprenitcepage(ScenarioContext context) : base(context)
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

