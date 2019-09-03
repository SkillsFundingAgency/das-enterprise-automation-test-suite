using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly ApprovalsConfig _config;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = new TabHelper(context.GetWebDriver());
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
        }

        public ProviderReviewYourCohortPage AddApprentice(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage CurrentCohortDetails()
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

            return new ProviderIndexPage(_context)
                    .StartNow()
                    .SubmitValidLoginDetails()
                    .GoToProviderYourCohortsPage()
                    .GoToCohortsToReviewPage()
                    .SelectViewCurrentCohortDetails();
        }

        public ProviderReviewYourCohortPage EditApprentice()
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            var totalNoOfApprentices = providerReviewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                int j = 0;
                var ulnFields = providerReviewYourCohortPage.ApprenticeUlns();
                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("–"))
                    {
                        providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(j)
                                                      .EnterUlnAndSave();
                        break;
                    }
                    j++;
                }
            }

            return providerReviewYourCohortPage;
        }
    }
}
