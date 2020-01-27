using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class End2EndSteps
    {
        private readonly ScenarioContext _context;
        private readonly End2EndStepsHelper _end2EndStepsHelper;
        private ApplicationOverviewPage _overviewPage;
        private EnterUkprnPage _enterUkprnPage;

        public End2EndSteps(ScenarioContext context)
        {
            _context = context;
            _end2EndStepsHelper = new End2EndStepsHelper(_context);
        }

        [Given(@"the provider initates an application as main route company")]
        public void GivenTheProviderInitatesAnApplicationAsMainRouteCompany()
        {
            var termsConditionsMakingApplicationPage = _end2EndStepsHelper.SubmitValidUserDetails();

            _enterUkprnPage = _end2EndStepsHelper.AcceptAndContinue(termsConditionsMakingApplicationPage);

            _overviewPage =  _end2EndStepsHelper.CompleteProviderRouteSection(_enterUkprnPage);
        }

        [When(@"the provider completes Your organisation section")]
        public void WhenTheProviderCompletesYourOrganisationSection()
        {
            _overviewPage = _end2EndStepsHelper.CompleteYourOrganisationSection(_overviewPage);
        }

        [When(@"the provider completes Financial evidence section")]
        public void WhenTheProviderCompletesFinancialEvidenceSection()
        {
            _overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence(_overviewPage);
        }

        [When(@"the provider completes Criminal and Compliance section")]
        public void WhenTheProviderCompletesCriminalAndComplianceSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesCriminalAndComplianceSection(_overviewPage);
        }

        [When(@"the provider completes Protecting your apprentices section")]
        public void WhenTheProviderCompletesProtectingYourApprenticesSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesProtectingYourApprenticesSection(_overviewPage);
        }

        [When(@"the provider completes Readiness to engage section")]
        public void WhenTheProviderCompletesReadinessToEngageSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesReadinessToEngageSection(_overviewPage);
        }

        [When(@"the provider completes Planning apprenticeship training section")]
        public void WhenTheProviderCompletesPlanningApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTrainingSection(_overviewPage);
        }

        [When(@"the provider completes Delivering apprenticeship training section")]
        public void WhenTheProviderCompletesDeliveringApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTrainingSection(_overviewPage);
        }

        [When(@"the provider completes Evaluating apprenticeship training section")]
        public void WhenTheProviderCompletesEvaluatingApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesEvaluatingApprenticeshipTrainingSection(_overviewPage);
        }

        [Then(@"the provider completes Finish section")]
        public void ThenTheProviderCompletesFinishSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesFinishSection(_overviewPage);
        }
    }
}
