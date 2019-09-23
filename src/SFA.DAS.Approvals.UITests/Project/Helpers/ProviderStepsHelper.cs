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
        private readonly ProviderPortalLoginHelper _loginHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = new TabHelper(context.GetWebDriver());
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _loginHelper = new ProviderPortalLoginHelper(_context);
        }

        public ProviderHomePage GoToProviderHomePage()
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                _loginHelper.ReLogin();
            }
            else if (_loginHelper.IsIndexPageDisplayed())
            {
                return new ProviderIndexPage(_context)
                    .StartNow()
                    .SubmitValidLoginDetails();
            }
            return new ProviderHomePage(_context);
        }

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
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
            return GoToProviderHomePage()
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

        public void Approve(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            providerReviewYourCohortPage.SelectContinueToApproval()
                .SubmitApprove();
        }
    }
}
