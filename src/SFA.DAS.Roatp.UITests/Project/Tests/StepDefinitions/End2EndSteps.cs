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
        private ApplicationSubmittedPage _applicationSubmittedPage;

        public End2EndSteps(ScenarioContext context)
        {
            _context = context;
            _end2EndStepsHelper = new End2EndStepsHelper(_context);
        }

        private EnterUkprnPage AcceptTermsAndCondition()
        {
            var termsConditionsMakingApplicationPage = _end2EndStepsHelper.SubmitValidUserDetails();

            return _end2EndStepsHelper.AcceptAndContinue(termsConditionsMakingApplicationPage);
        }

        [Given(@"the provider initates an application as main route company")]
        public void GivenTheProviderInitatesAnApplicationAsMainRouteCompany()
        {
            var enterUkprnPage = AcceptTermsAndCondition();

            _overviewPage =  _end2EndStepsHelper.CompleteProviderMainRouteSection(enterUkprnPage);
        }

        [Given(@"the provider initates an application as employer route charity")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerRouteCharity()
        {
            var enterUkprnPage = AcceptTermsAndCondition();

            _overviewPage = _end2EndStepsHelper.CompleteProviderCharityRouteSection(enterUkprnPage);
        }


        [When(@"the provider completes Your organisation section")]
        public void WhenTheProviderCompletesYourOrganisationSection()
        {
            _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1(_overviewPage);
        }

        [When(@"the provider completes Your organisation section for charity")]
        public void WhenTheProviderCompletesYourOrganisationSectionForCharity()
        {
            _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_Charity(_overviewPage);
        }

        [When(@"the provider completes Financial evidence section")]
        public void WhenTheProviderCompletesFinancialEvidenceSection()
        {
            _overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence_Section2(_overviewPage);
        }

        [When(@"the provider completes Criminal and Compliance section")]
        public void WhenTheProviderCompletesCriminalAndComplianceSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesCriminalAndCompliance_Section3(_overviewPage);
        }

        [When(@"the provider completes Protecting your apprentices section")]
        public void WhenTheProviderCompletesProtectingYourApprenticesSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesProtectingYourApprentices_Section4(_overviewPage);
        }

        [When(@"the provider completes Readiness to engage section")]
        public void WhenTheProviderCompletesReadinessToEngageSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesReadinessToEngage_Section5(_overviewPage);
        }

        [When(@"the provider completes Planning apprenticeship training section")]
        public void WhenTheProviderCompletesPlanningApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTraining_Section6(_overviewPage);
        }

        [When(@"the provider completes Delivering apprenticeship training section")]
        public void WhenTheProviderCompletesDeliveringApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTraining_Section7(_overviewPage);
        }

        [When(@"the provider completes Evaluating apprenticeship training section")]
        public void WhenTheProviderCompletesEvaluatingApprenticeshipTrainingSection()
        {
            _overviewPage = _end2EndStepsHelper.CompletesEvaluatingApprenticeshipTraining_Section8(_overviewPage);
        }

        [Then(@"the provider completes Finish section")]
        public void ThenTheProviderCompletesFinishSection()
        {
            _applicationSubmittedPage = _end2EndStepsHelper.CompletesFinish_Section9(_overviewPage);
        }
    }
}
