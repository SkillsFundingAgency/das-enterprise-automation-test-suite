using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
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
        private readonly IWebDriver _webDriver;
        private readonly ApprovalsConfig _config;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _objectContext = _context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
        }

        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            var handle = _webDriver.CurrentWindowHandle;

            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{_config.AP_ProviderAppUrl}','_blank');");

            var handles = _webDriver.WindowHandles;

            var newWindow = handles.FirstOrDefault(x => x != handle);

            _webDriver.SwitchTo().Window(newWindow);

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
            providerReviewYourCohortPage.SelectContinueToApproval()
                .SubmitApprove();
        }
    }
}
