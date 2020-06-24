using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Helpers
{
    public class ReviewerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private const string _applicationName = "Reviewer";
        private readonly string _raav2qaBaseUrl;
             

        public ReviewerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _helper = new RestartWebDriverHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _raav2qaBaseUrl = UrlConfig.RAAV2QA_BaseUrl;
        }

        public Reviewer_HomePage GoToReviewerHomePage(bool restart)
        {
            if (restart)
            {
                _helper.RestartWebDriver(_raav2qaBaseUrl, _applicationName);
            }
            else
            {
                _objectContext.SetCurrentApplicationName(_applicationName);

                _tabHelper.OpenInNewTab(_raav2qaBaseUrl);
            }

            new IdamsPage(_context)
               .LoginToAccess1Staff();

            return new SignInPage(_context)
                .SubmitReviewerLoginDetails();
        }

        public void VerifyEmployerNameAndApprove(bool restart) => ReviewVacancy(restart).VerifyEmployerName().Approve();

        public void Refer(bool restart) => ReviewVacancy(restart).Refer();

        public void VerifyDisabilityConfidenceAndApprove(bool restart) => ReviewVacancy(restart).VerifyDisabilityConfident().Approve();

        private Reviewer_VacancyPreviewPage ReviewVacancy(bool restart) => GoToReviewerHomePage(restart).ReviewVacancy();
    }
}
