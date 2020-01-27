using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class End2EndStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly YourOrganisationSectionHelper _yourOrganisationSectionHelper;
        private readonly FinancialEvidenceSectionHelper _financialEvidenceSectionHelper;
        private readonly CriminalAndComplianceSectionHelper _criminalAndComplianceSectionHelper;
        private readonly ProtectingYourApprenticesSectionHelper _protectingYourApprenticesSectionHelper;
        private readonly ReadinessToEngageSectionHelper _readinessToEngageSectionHelper;
        private readonly PlanningApprenticeshipTrainingSectionHelper _planningApprenticeshipTrainingSectionHelper;
        private readonly DeliveringApprenticeshipTrainingSectionHelper _deliveringApprenticeshipTrainingSectionHelper;
        private readonly EvaluatingApprenticeshipTrainingSectionHelper _evaluatingApprenticeshipTrainingSectionHelper;
        private readonly FinishSectionHelper _finishSectionHelper;

        public End2EndStepsHelper(ScenarioContext context)
        {
            _context = context;
            _yourOrganisationSectionHelper = new YourOrganisationSectionHelper();
            _financialEvidenceSectionHelper = new FinancialEvidenceSectionHelper();
            _criminalAndComplianceSectionHelper = new CriminalAndComplianceSectionHelper();
            _protectingYourApprenticesSectionHelper = new ProtectingYourApprenticesSectionHelper();
            _readinessToEngageSectionHelper = new ReadinessToEngageSectionHelper();
            _planningApprenticeshipTrainingSectionHelper = new PlanningApprenticeshipTrainingSectionHelper();
            _deliveringApprenticeshipTrainingSectionHelper = new DeliveringApprenticeshipTrainingSectionHelper();
            _evaluatingApprenticeshipTrainingSectionHelper = new EvaluatingApprenticeshipTrainingSectionHelper();
            _finishSectionHelper = new FinishSectionHelper();
        }

        internal TermsConditionsMakingApplicationPage SubmitValidUserDetails()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectingNoOptionForFirstTimeSignInAndContinue()
                .SubmitValidUserDetails();
        }

        internal EnterUkprnPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue();

        internal ApplicationOverviewPage CompleteProviderRouteSection(EnterUkprnPage enterUkprnPage)
        {
            return enterUkprnPage
                .EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain()
                .VerifyIntroductionStatus(StatusHelper.StatusNext);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_2(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesCriminalAndComplianceSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_1(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_2(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_3(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesProtectingYourApprenticesSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_1(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_2(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_3(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_4(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_5(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesReadinessToEngageSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_1(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_2(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_3(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_4(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_5(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_6(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesPlanningApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_5(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesDeliveringApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesEvaluatingApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesFinishSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_1(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_2(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_3(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_4(applicationOverviewPage);
            return applicationOverviewPage;
        }
    }
}
