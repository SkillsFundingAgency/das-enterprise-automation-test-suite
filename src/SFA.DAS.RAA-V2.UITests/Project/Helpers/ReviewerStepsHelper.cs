using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public class ReviewerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private readonly RAAV2Config _config;
        private const string _applicationName = "Reviewer";

        public ReviewerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _helper = new RestartWebDriverHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetRAAV2Config<RAAV2Config>();
        }

        public Reviewer_HomePage GoToReviewerHomePage(bool restart)
        {
            if (restart)
            {
                _helper.RestartWebDriver(_config.RAAV2QABaseUrl, _applicationName);
            }
            else
            {
                _objectContext.SetCurrentApplicationName(_applicationName);
                _tabHelper.OpenInNewtab(_config.RAAV2QABaseUrl);
            }

            new IdamsPage(_context)
               .ManageStaffIdams();

            return new SignInPage(_context)
                .SubmitReviewerLoginDetails();
        }
        public void VerifyEmployerNameAndApprove(bool restart) => ReviewVacancy(restart).VerifyEmployerName().Approve();

        public void VerifyDisabilityConfidenceAndApprove(bool restart) => ReviewVacancy(restart).VerifyDisabilityConfident().Approve();

        private Reviewer_VacancyPreviewPage ReviewVacancy(bool restart) => GoToReviewerHomePage(restart).ReviewVacancy();
    }
}
