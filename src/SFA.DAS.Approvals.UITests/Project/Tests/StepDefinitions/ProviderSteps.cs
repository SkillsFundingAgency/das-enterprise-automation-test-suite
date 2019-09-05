using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprovalsConfig _config;
        private readonly TabHelper _tabHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = new TabHelper(context.GetWebDriver());
        }

        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

            var providerReviewYourCohortPage = ReviewTheCohort();

            ApproveTheCohort(providerReviewYourCohortPage);
        }

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer()
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

            var providerReviewYourCohortPage = ReviewTheCohort();

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        private ProviderReviewYourCohortPage ReviewTheCohort()
        {
            var providerReviewYourCohortPage = new ProviderIndexPage(_context)
                .StartNow()
                .SubmitValidLoginDetails()
                .GoToProviderYourCohortsPage()
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails();

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

        private void ApproveTheCohort(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            providerReviewYourCohortPage.SelectContinueToApproval()
                                        .SubmitApprove();
        }
    }
}
