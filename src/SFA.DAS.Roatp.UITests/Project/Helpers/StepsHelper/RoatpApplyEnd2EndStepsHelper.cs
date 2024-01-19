using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class RoatpApplyEnd2EndStepsHelper()
    {
        public static void CompletesTheApplyJourney(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            if (applicationRoute == ApplicationRoute.MainProviderRoute) { CompletesTheApplyJourneyAsMainRoute(selectRouteStepsHelper, applicationRoute); }

            if (applicationRoute == ApplicationRoute.EmployerProviderRoute) { CompletesTheApplyJourneyAsEmployerRoute(selectRouteStepsHelper, applicationRoute); }

            if (applicationRoute == ApplicationRoute.SupportingProviderRoute) { CompletesTheApplyJourneyAsSupportRoute(selectRouteStepsHelper, applicationRoute); }

            if (applicationRoute == ApplicationRoute.EmployerProviderRouteForExistingProvider) { CompletesTheApplyJourneyAsEmployerRoute_Existinprovider(selectRouteStepsHelper, applicationRoute); }

            if (applicationRoute == ApplicationRoute.MainProviderRouteForExistingProvider) { CompletesTheApplyJourneyAsMainRoute_Existingprovider(selectRouteStepsHelper, applicationRoute); }

            if (applicationRoute == ApplicationRoute.SupportingProviderRouteForExistingProvider) { CompletesTheApplyJourneyAsSupportRoute_Existingprovider(selectRouteStepsHelper, applicationRoute); }
        }

        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsMainRoute(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var overviewPage = selectRouteStepsHelper.CompleteProviderMainRouteSection();
            overviewPage = CompleteYourOrganisation_Section1(overviewPage);
            overviewPage = CompleteFinancialEvidence_Section2(overviewPage);
            overviewPage = CompletesCriminalAndCompliance_Section3(overviewPage);
            overviewPage = CompletesProtectingYourApprentices_Section4(overviewPage);
            overviewPage = CompletesReadinessToEngage_Section5(overviewPage);
            overviewPage = CompletesPlanningApprenticeshipTraining_Section6(overviewPage, applicationRoute);
            overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(overviewPage);
            overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8(overviewPage);
            return CompletesFinish_Section9(overviewPage);
        }

        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsEmployerRoute(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var _overviewPage = selectRouteStepsHelper.CompleteProviderCharityRouteSection();
            _overviewPage = CompleteYourOrganisation_Section1_Charity(_overviewPage);
            _overviewPage = CompleteFinancialEvidence_Section2_ForNoUltimateParentCompany(_overviewPage);
            _overviewPage = CompletesCriminalAndCompliance_Section3(_overviewPage);
            _overviewPage = CompletesProtectingYourApprentices_Section4(_overviewPage);
            _overviewPage = CompletesReadinessToEngage_Section5_Charity(_overviewPage);
            _overviewPage = CompletesPlanningApprenticeshipTraining_Section6_Charity(_overviewPage, applicationRoute);
            _overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_EmployerRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8(_overviewPage);
            return CompletesFinish_Section9(_overviewPage);
        }

        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsEmployerRoute_Existinprovider(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var _overviewPage = selectRouteStepsHelper.CompleteProviderEmployerRouteSection_ExistingProvider();
            _overviewPage = CompleteYourOrganisation_Section1_Charity(_overviewPage);
            _overviewPage = CompleteFinancialEvidence_Section2_ForNoUltimateParentCompany(_overviewPage);
            _overviewPage = CompletesCriminalAndCompliance_Section3(_overviewPage);
            _overviewPage = CompletesProtectingYourApprentices_Section4(_overviewPage);
            _overviewPage = CompletesReadinessToEngage_Section5_Charity(_overviewPage);
            _overviewPage = CompletesPlanningApprenticeshipTraining_Section6_Charity(_overviewPage, applicationRoute);
            _overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_EmployerRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8(_overviewPage);
            return CompletesFinish_Section9(_overviewPage);
        }
        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsMainRoute_Existingprovider(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var overviewPage = selectRouteStepsHelper.CompleteProviderMainRouteSection_ExistingProvider();
            overviewPage = CompleteYourOrganisation_Section1(overviewPage);
            overviewPage = CompleteFinancialEvidence_Section2(overviewPage);
            overviewPage = CompletesCriminalAndCompliance_Section3(overviewPage);
            overviewPage = CompletesProtectingYourApprentices_Section4(overviewPage);
            overviewPage = CompletesReadinessToEngage_Section5(overviewPage);
            overviewPage = CompletesPlanningApprenticeshipTraining_Section6(overviewPage, applicationRoute);
            overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(overviewPage);
            overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8(overviewPage);
            return CompletesFinish_Section9(overviewPage);
        }


        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsSupportRoute(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var _overviewPage = selectRouteStepsHelper.CompleteProviderSupportRouteSection();
            _overviewPage = CompleteYourOrganisation_Section1_Support_Soletrader(_overviewPage);
            _overviewPage = CompleteFinancialEvidence_Section2_ForSupportingRoute(_overviewPage);
            _overviewPage = CompletesCriminalAndCompliance_Section3(_overviewPage);
            _overviewPage = CompletesProtectingYourApprentices_Section4_SupportingRoute(_overviewPage);
            _overviewPage = NotRequiredReadinessToEngage_Section5(_overviewPage);
            _overviewPage = CompletesPlanningApprenticeshipTraining_Section6_SupportingRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_SupportingRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8_SupportingRoute(_overviewPage);
            return CompletesFinish_Section9_SupportingRoute(_overviewPage);
        }

        public static ApplicationSubmittedPage CompletesTheApplyJourneyAsSupportRoute_Existingprovider(SelectRouteStepsHelper selectRouteStepsHelper, ApplicationRoute applicationRoute)
        {
            var _overviewPage = selectRouteStepsHelper.CompleteProviderSupportingRouteSection_ExistingProvider();
            _overviewPage = CompleteYourOrganisation_Section1_Support_Soletrader(_overviewPage);
            _overviewPage = CompleteFinancialEvidence_Section2_ForSupportingRoute(_overviewPage);
            _overviewPage = CompletesCriminalAndCompliance_Section3(_overviewPage);
            _overviewPage = CompletesProtectingYourApprentices_Section4_SupportingRoute(_overviewPage);
            _overviewPage = NotRequiredReadinessToEngage_Section5(_overviewPage);
            _overviewPage = CompletesPlanningApprenticeshipTraining_Section6_SupportingRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesDeliveringApprenticeshipTraining_Section7_SupportingRoute(_overviewPage, applicationRoute);
            _overviewPage = CompletesEvaluatingApprenticeshipTraining_Section8_SupportingRoute(_overviewPage);
            return CompletesFinish_Section9_SupportingRoute(_overviewPage);
        }


        public static ApplicationOverviewPage CompleteYourOrganisation_Section1_Support_Soletrader(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1_SupportRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_NotACompany(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_Support(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeGTA(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_Support(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1_Support_Company(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1_SupportRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeGTA(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_Support(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_NotACompany(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_Charity(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllForEmployerRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }
        public static ApplicationOverviewPage VerifyAnswers_ChangeRouteMainToEmployer(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_ChangeRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_ChangeRoute_VerifySectionExemptions(applicationOverviewPage);
            return applicationOverviewPage;
        }
        public static ApplicationOverviewPage VerifyAnswers_ChangeRouteEmployerToSupporting(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1_SupportRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_ChangeRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_ChangeRouteEmployerToSupporting_VerifySectionExemptions(applicationOverviewPage);
            return applicationOverviewPage;
        }
        public static ApplicationOverviewPage VerifyAnswers_ChangeRouteSupportingToMain(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_ChangeRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_5ChangeRouteSupportingToMain_VerifySectionExemptions(applicationOverviewPage);
            return applicationOverviewPage;
        }
        public static ApplicationOverviewPage VerifyAnswers_ChangeRouteEmployerToMain(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_ChangeRoute(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_5DifferentPath_ChangeRouteEmployerToMain_VerifySectionExemptions(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1_GovernmentStatue(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_HasWebsite(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_GovernmentStatue(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllMainRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllMainRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1CharityAndCompany(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_CharityAndCompany(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllMainRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteYourOrganisation_Section1_FHAExempt(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_SixthFormCollege(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllForEmployerRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteFinancialEvidence_Section2(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_2(applicationOverviewPage);
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteFinancialEvidence_Section2_ForNoUltimateParentCompany(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_2_ForNoUltimateParentCompany(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompleteFinancialEvidence_Section2_ForSupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = FinancialEvidence_Section2_Helper.CompleteFinancialEvidence_2_ForSupportingRoute(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesCriminalAndCompliance_Section3(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = CriminalAndCompliance_Section3_Helper.CompleteCriminalAndCompliance_1(applicationOverviewPage);
            applicationOverviewPage = CriminalAndCompliance_Section3_Helper.CompleteCriminalAndCompliance_2(applicationOverviewPage);
            applicationOverviewPage = CriminalAndCompliance_Section3_Helper.CompleteCriminalAndCompliance_3(applicationOverviewPage);
            applicationOverviewPage = CriminalAndCompliance_Section3_Helper.CompleteCriminalAndCompliance_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesProtectingYourApprentices_Section4(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_1(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_2(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_3(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_4(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_5(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesProtectingYourApprentices_Section4_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_1(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_3(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_4(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_5(applicationOverviewPage);
            applicationOverviewPage = ProtectingYourApprentices_Section4_Helper.CompleteProtectingYourApprentices_6(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage NotRequiredReadinessToEngage_Section5(ApplicationOverviewPage applicationOverviewPage)
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

        public static ApplicationOverviewPage CompletesReadinessToEngage_Section5(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_1(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_2(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_3(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_4(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_5(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_6(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_7(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_8(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesReadinessToEngage_Section5_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_1(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_5(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_6(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_7(applicationOverviewPage);
            applicationOverviewPage = ReadinessToEngage_Section5_Helper.CompleteReadinessToEngage_8(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_2(applicationOverviewPage, applicationroute);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_4_MainRoute(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_5(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6_Charity(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_2_Charity(applicationOverviewPage, applicationroute);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_5(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesPlanningApprenticeshipTraining_Section6_SupportingRoute(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = PlanningApprenticeshipTraining_Section6_Helper.CompletePlanningApprenticeshipTraining_2_Support(applicationOverviewPage, applicationroute);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_5_MainRoute(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_6(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_EmployerRoute(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_5_EmployerRoute(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_6_NotRequired(applicationOverviewPage, applicationroute);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesDeliveringApprenticeshipTraining_Section7_SupportingRoute(ApplicationOverviewPage applicationOverviewPage, ApplicationRoute applicationroute)
        {
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_4(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_5_SupportingRoute(applicationOverviewPage);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_6_NotRequired(applicationOverviewPage, applicationroute);
            applicationOverviewPage = DeliveringApprenticeshipTraining_Section7_Helper.CompleteDeliveringApprenticeshipTraining_7(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesEvaluatingApprenticeshipTraining_Section8(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_3(applicationOverviewPage);
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_4(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationOverviewPage CompletesEvaluatingApprenticeshipTraining_Section8_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_1(applicationOverviewPage);
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_2(applicationOverviewPage);
            applicationOverviewPage = EvaluatingApprenticeshipTraining_Section8_Helper.CompleteEvaluatingApprenticeshipTraining_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        public static ApplicationSubmittedPage CompletesFinish_Section9(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = Finish_Section9_Helper.UnhappyPathFinish_123(applicationOverviewPage);
            applicationOverviewPage = Finish_Section9_Helper.CompleteFinish_3(applicationOverviewPage);
            return Finish_Section9_Helper.CompleteFinish_4(applicationOverviewPage);
        }

        public static ApplicationSubmittedPage CompletesFinish_Section9_SupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = Finish_Section9_Helper.CompleteFinish_1(applicationOverviewPage);
            applicationOverviewPage = Finish_Section9_Helper.CompleteFinish_2(applicationOverviewPage);
            return Finish_Section9_Helper.CompleteFinish_4(applicationOverviewPage);
        }

        public static ApplicationOverviewPage CompleteSecion1_UnHappyPath(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_UnhappyPaths(applicationOverviewPage);
            applicationOverviewPage = YourOrganisation_Section1_Helper.UnhappyPathJourney_YourOrganisationSection_5(applicationOverviewPage);
            return applicationOverviewPage;
        }
    }
}