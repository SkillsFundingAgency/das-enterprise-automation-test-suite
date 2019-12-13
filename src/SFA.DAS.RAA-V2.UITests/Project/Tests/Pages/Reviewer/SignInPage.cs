using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer
{
    public class SignInPage : SignInBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RAAV2Config _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV2Config<RAAV2Config>();
        }

        public Reviewer_HomePage SubmitReviewerLoginDetails()
        {
            SubmitValidLoginDetails(_config.RAAV2QAUserName, _config.RAAV2QAPassword);

            return new Reviewer_HomePage(_context);
        }
    }
}
