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

        [When(@"the provider adds (.*) apprentices approves them and sends to employer to approve")]
        public void WhenTheProviderAddsApprenticesApprovesThemAndSendsToEmployerToApprove(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();

        }


        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            var providerReviewYourCohortPage = EditApprentice();

            ApproveTheCohort(providerReviewYourCohortPage);
        }

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer()
        {
            var providerReviewYourCohortPage = EditApprentice();

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }


        private ProviderReviewYourCohortPage AddApprentice(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            return providerReviewYourCohortPage;
        }

        private ProviderReviewYourCohortPage CurrentCohortDetails()
        {
            _tabHelper.OpenInNewtab(_config.AP_ProviderAppUrl);

            return new ProviderIndexPage(_context)
                    .StartNow()
                    .SubmitValidLoginDetails()
                    .GoToProviderYourCohortsPage()
                    .GoToCohortsToReviewPage()
                    .SelectViewCurrentCohortDetails();
        }

        private ProviderReviewYourCohortPage EditApprentice()
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

        private void ApproveTheCohort(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            providerReviewYourCohortPage.SelectContinueToApproval()
                                        .SubmitApprove();
        }
    }
}
