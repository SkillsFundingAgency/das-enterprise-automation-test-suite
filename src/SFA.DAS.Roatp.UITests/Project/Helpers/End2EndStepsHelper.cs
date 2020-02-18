using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.Finish_Section9;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class End2EndStepsHelper
    {
        private readonly YourOrganisation_Section1_Helper _yourOrganisationSectionHelper;
        private readonly FinancialEvidence_Section2_Helper _financialEvidenceSectionHelper;
        private readonly CriminalAndCompliance_Section3_Helper _criminalAndComplianceSectionHelper;
        private readonly ProtectingYourApprentices_Section4_Helper _protectingYourApprenticesSectionHelper;
        private readonly ReadinessToEngage_Section5_Helper _readinessToEngageSectionHelper;
        private readonly PlanningApprenticeshipTraining_Section6_Helper _planningApprenticeshipTrainingSectionHelper;
        private readonly DeliveringApprenticeshipTraining_Section7_Helper _deliveringApprenticeshipTrainingSectionHelper;
        private readonly EvaluatingApprenticeshipTraining_Section8_Helper _evaluatingApprenticeshipTrainingSectionHelper;
        private readonly Finish_Section9_Helper _finishSectionHelper;

        public End2EndStepsHelper()
        {
            _yourOrganisationSectionHelper = new YourOrganisation_Section1_Helper();
            _financialEvidenceSectionHelper = new FinancialEvidence_Section2_Helper();
            _criminalAndComplianceSectionHelper = new CriminalAndCompliance_Section3_Helper();
            _protectingYourApprenticesSectionHelper = new ProtectingYourApprentices_Section4_Helper();
            _readinessToEngageSectionHelper = new ReadinessToEngage_Section5_Helper();
            _planningApprenticeshipTrainingSectionHelper = new PlanningApprenticeshipTraining_Section6_Helper();
            _deliveringApprenticeshipTrainingSectionHelper = new DeliveringApprenticeshipTraining_Section7_Helper();
            _evaluatingApprenticeshipTrainingSectionHelper = new EvaluatingApprenticeshipTraining_Section8_Helper();
            _finishSectionHelper = new Finish_Section9_Helper();
        }

        internal ApplicationOverviewPage CompleteYourOrganisation_Section1_Support(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1_SupportRoute(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2_NotACompany(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_Support(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeGTA(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_Support(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteYourOrganisation_Section1_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2_NotACompany(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_Charity(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_NoToAll(applicationOverviewPage);
            return applicationOverviewPage;
        }


        internal ApplicationOverviewPage CompleteYourOrganisation_Section1(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_NoToAll(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_Section2(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_2(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_Section2_ForNoUltimateParentCompany(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_2_ForNoUltimateParentCompany(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_Section2_ForSupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_2_ForSupportingRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesCriminalAndCompliance_Section3(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_1(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_2(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_3(applicationOverviewPage);
            applicationOverviewPage = _criminalAndComplianceSectionHelper.CompleteCriminalAndCompliance_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesProtectingYourApprentices_Section4(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_1(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_2(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_3(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_4(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_5(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesProtectingYourApprentices_Section4_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_1(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_3(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_4(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_5(applicationOverviewPage);
            applicationOverviewPage = _protectingYourApprenticesSectionHelper.CompleteProtectingYourApprentices_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage NotRequiredReadinessToEngage_Section5(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = applicationOverviewPage.VerifyIntroductionStatus_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyEngaging_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyComplaints_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyContract_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyCommitment_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyPriorLearning_Section5(StatusHelper.NotRequired);
            applicationOverviewPage = applicationOverviewPage.VerifyWorkingWithSubcontractors_Section5(StatusHelper.NotRequired);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesReadinessToEngage_Section5(ApplicationOverviewPage applicationOverviewPage)
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

        internal ApplicationOverviewPage CompletesReadinessToEngage_Section5_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_1(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_5(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_6(applicationOverviewPage);
            applicationOverviewPage = _readinessToEngageSectionHelper.CompleteReadinessToEngage_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_5(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_2_Charity(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_5(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _planningApprenticeshipTrainingSectionHelper.CompletePlanningApprenticeshipTraining_2_Support(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_5_MainRoute(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_EmployerRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_5_EmployerRoute(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_5_SupportingRoute(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = _deliveringApprenticeshipTrainingSectionHelper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesEvaluatingApprenticeshipTraining_Section8(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesEvaluatingApprenticeshipTraining_Section8_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = _evaluatingApprenticeshipTrainingSectionHelper.CompleteEvaluatingApprenticeshipTraining_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationSubmittedPage CompletesFinish_Section9(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_1(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_2(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_3(applicationOverviewPage);
            return _finishSectionHelper.CompleteFinish_4(applicationOverviewPage);
        }
        internal ApplicationSubmittedPage CompletesFinish_Section9_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_1(applicationOverviewPage);
            applicationOverviewPage = _finishSectionHelper.CompleteFinish_2(applicationOverviewPage);
            return _finishSectionHelper.CompleteFinish_4(applicationOverviewPage);
        }
    }
}