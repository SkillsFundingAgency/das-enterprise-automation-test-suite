using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class End2EndSteps
    {
        private readonly ObjectContext _objectContext;
        private readonly RoatpApplyEnd2EndStepsHelper _end2EndStepsHelper;
        private readonly SelectRouteStepsHelper _selectRouteStepsHelper;
        
        private ApplicationOverviewPage _overviewPage;
        private readonly FinancialEvidence_Section2_Helper _financialEvidence_Section2_Helper;

        public End2EndSteps(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _end2EndStepsHelper = new RoatpApplyEnd2EndStepsHelper();
            _selectRouteStepsHelper = new SelectRouteStepsHelper(context);
            _financialEvidence_Section2_Helper = new FinancialEvidence_Section2_Helper();
        }

        [Given(@"the provider completes the Apply Journey as (Main Provider Route|Supporting Provider Route|Employer Provider Route)")]
        public void GivenTheProviderCompletesTheApplyJourneyAsMainRouteCompany(ApplicationRoute applicationRoute)
        {
            _objectContext.SetApplicationRoute(applicationRoute);

            _end2EndStepsHelper.CompletesTheApplyJourney(_selectRouteStepsHelper, applicationRoute);
        }

        [Then(@"the provider do not accept the Terms and conditions")]
        public void ThenTheProviderDoNotAcceptTheTermsAndConditions() => _selectRouteStepsHelper.DoNotAcceptTermsConditions();

        [Given(@"the provider initates an application as main route company")]
        public void GivenTheProviderInitatesAnApplicationAsMainRouteCompany() => _overviewPage = _selectRouteStepsHelper.CompleteProviderMainRouteSection();

        [Given(@"the provider initates an application as employer route charity")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerRouteCharity() => _overviewPage = _selectRouteStepsHelper.CompleteProviderCharityRouteSection();

        [Given(@"the provider initates an application as employer route")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerRouteCompany() => _overviewPage = _selectRouteStepsHelper.CompleteProviderCharityRouteSection();

        [Given(@"the provider initates an application as supporting route")]
        public void GivenTheProviderInitatesAnApplicationAsSupportingRoute() => _overviewPage = _selectRouteStepsHelper.CompleteProviderSupportRouteSection();

        [When(@"the provider completes Your organisation section")]
        public void WhenTheProviderCompletesYourOrganisationSection() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1(_overviewPage);

        [When(@"the provider completes Your organisation section for supporting route org type company")]
        public void WhenTheProviderCompletesYourOrganisationSectionForSupportingRouteOrgTypeCompany() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_Support_Company(_overviewPage);

        [When(@"the provider completes Your organisation section for company and charity")]
        public void WhenTheProviderCompletesYourOrganisationSectionForCompanyAndCharity() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1CharityAndCompany(_overviewPage);

        [When(@"the provider completes Your organisation section for charity")]
        public void WhenTheProviderCompletesYourOrganisationSectionForCharity() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_Charity(_overviewPage);

        [When(@"the provider completes Your organisation section for Government Statue has a website")]
        public void WhenTheProviderCompletesYourOrganisationSectionForGovernmentStatueHasAWebsite() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_GovernmentStatue(_overviewPage);

        [When(@"the provider completes Your organisation section for FHA exemptions")]
        public void WhenTheProviderCompletesYourOrganisationSectionForFHAExemptions() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_FHAExempt(_overviewPage);

        [When(@"the provider completes Your organisation section for supporting route")]
        public void WhenTheProviderCompletesYourOrganisationSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1_Support_Soletrader(_overviewPage);

        [When(@"the provider completes Financial evidence section")]
        public void WhenTheProviderCompletesFinancialEvidenceSection() => _overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence_Section2(_overviewPage);

        [When(@"the provider completes Financial Evidence section for no ultimate parent company")]
        public void WhenTheProviderCompletesFinancialEvidenceSectionForNoUltimateParentCompany() => _overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence_Section2_ForNoUltimateParentCompany(_overviewPage);

        [When(@"the provider verifies Financial Evidence section status as not required")]
        public void WhenTheProviderVerifiesFinancialEvidenceSectionStatusAsNotRequired() => _overviewPage = _financialEvidence_Section2_Helper.VerifyFinancialEvidenceSectionExempted(_overviewPage);

        [When(@"the provider completes Financial Evidence section for supporting route")]
        public void WhenTheProviderCompletesFinancialEvidenceSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence_Section2_ForSupportingRoute(_overviewPage);

        [When(@"the provider completes Criminal and Compliance section")]
        public void WhenTheProviderCompletesCriminalAndComplianceSection() => _overviewPage = _end2EndStepsHelper.CompletesCriminalAndCompliance_Section3(_overviewPage);

        [When(@"the provider completes Protecting your apprentices section")]
        public void WhenTheProviderCompletesProtectingYourApprenticesSection() => _overviewPage = _end2EndStepsHelper.CompletesProtectingYourApprentices_Section4(_overviewPage);

        [When(@"the provider completes Protecting your apprentices section for supporting route")]
        public void WhenTheProviderCompletesProtectingYourApprenticesSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompletesProtectingYourApprentices_Section4_SupportingRoute(_overviewPage);

        [When(@"the provider does not require to complete Readiness to engage section")]
        public void WhenTheProviderDoesNotRequireToCompleteReadinessToEngageSection() => _overviewPage = _end2EndStepsHelper.NotRequiredReadinessToEngage_Section5(_overviewPage);

        [When(@"the provider completes Readiness to engage section")]
        public void WhenTheProviderCompletesReadinessToEngageSection() => _overviewPage = _end2EndStepsHelper.CompletesReadinessToEngage_Section5(_overviewPage);

        [When(@"the provider completes Readiness to engage section for charity")]
        public void WhenTheProviderCompletesReadinessToEngageSectionForCharity() => _overviewPage = _end2EndStepsHelper.CompletesReadinessToEngage_Section5_Charity(_overviewPage);

        [When(@"the provider completes Planning apprenticeship training section")]
        public void WhenTheProviderCompletesPlanningApprenticeshipTrainingSection() => _overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTraining_Section6(_overviewPage);

        [When(@"the provider completes Planning apprenticeship training section for charity")]
        public void WhenTheProviderCompletesPlanningApprenticeshipTrainingSectionForCharity() => _overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTraining_Section6_Charity(_overviewPage);

        [When(@"the provider completes Planning apprenticeship training section for supporting route")]
        public void WhenTheProviderCompletesPlanningApprenticeshipTrainingSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTraining_Section6_SupportingRoute(_overviewPage);

        [When(@"the provider completes Delivering apprenticeship training section for main route")]
        public void WhenTheProviderCompletesDeliveringApprenticeshipTrainingSectionForMainRoute() => _overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(_overviewPage);

        [When(@"the provider completes Delivering apprenticeship training section for employer route")]
        public void WhenTheProviderCompletesDeliveringApprenticeshipTrainingSectionForEmployerRoute() => _overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTraining_Section7_EmployerRoute(_overviewPage);

        [When(@"the provider completes Delivering apprenticeship training section for supporting route")]
        public void WhenTheProviderCompletesDeliveringApprenticeshipTrainingSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTraining_Section7_SupportingRoute(_overviewPage);

        [When(@"the provider completes Evaluating apprenticeship training section")]
        public void WhenTheProviderCompletesEvaluatingApprenticeshipTrainingSection() => _overviewPage = _end2EndStepsHelper.CompletesEvaluatingApprenticeshipTraining_Section8(_overviewPage);

        [When(@"the provider completes Evaluating apprenticeship training section for supporting route")]
        public void WhenTheProviderCompletesEvaluatingApprenticeshipTrainingSectionForSupportingRoute() => _overviewPage = _end2EndStepsHelper.CompletesEvaluatingApprenticeshipTraining_Section8_SupportingRoute(_overviewPage);

        [Then(@"the provider completes Finish section")]
        public void ThenTheProviderCompletesFinishSection() => _end2EndStepsHelper.CompletesFinish_Section9(_overviewPage);

        [Then(@"the provider completes Finish section for supporting route")]
        public void ThenTheProviderCompletesFinishSectionForSupportingRoute() => _end2EndStepsHelper.CompletesFinish_Section9_SupportingRoute(_overviewPage);
    }
}
