using SFA.DAS.FrameworkHelpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Helpers
{
    public class ReviewerStepsHelper
    {
        private readonly ScenarioContext _context;

        public ReviewerStepsHelper(ScenarioContext context) => _context = context;

        public Reviewer_HomePage GoToReviewerHomePage(bool restart)
        {
            var applicationName = "Reviewer";
            var raav2qaBaseUrl = UrlConfig.RAAV2QA_BaseUrl;

            if (restart)
            {
                new RestartWebDriverHelper(_context).RestartWebDriver(raav2qaBaseUrl, applicationName);
            }
            else
            {
                _context.Get<ObjectContext>().SetCurrentApplicationName(applicationName);

                _context.Get<TabHelper>().OpenInNewTab(raav2qaBaseUrl);
            }

            new DfeAdminLoginStepsHelper(_context).LoginToASVacancyQa();

            return new Reviewer_HomePage(_context);
        }

        public void VerifyEmployerNameAndApprove(bool restart) => ReviewVacancy(restart).VerifyEmployerName().Approve();

        public void Refer(bool restart) => ReviewVacancy(restart).ReferTitle();

        public void VerifyDisabilityConfidenceAndApprove(bool restart) => ReviewVacancy(restart).VerifyDisabilityConfident().Approve();

        private Reviewer_VacancyPreviewPage ReviewVacancy(bool restart) => GoToReviewerHomePage(restart).ReviewVacancy();
    }
}
