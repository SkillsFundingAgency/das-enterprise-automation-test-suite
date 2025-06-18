using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class GatewayEndtoEndStepsHelpers
    {
        internal static GWApplicationOverviewPage CompleteOrganisationChecks_Section1(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_LegalName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_TradingName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_OrganisationStatus(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_Address(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_ICONumber(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_WebsiteAddress(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_OrganisationHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompleteOrganisationChecks_Section1_TradingNameNotRequired(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_LegalName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.NotRequiredOrganisationChecks_TradingName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_OrganisationStatus(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_Address(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_ICONumber(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_WebsiteAddress(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationChecks_Section1Helpers.PassOrganisationChecks_OrganisationHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompletePeopleInControlChecks_Section2(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.PassPeopleInControlChecks_PeopleInControl(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.PassPeopleInControlChecks_PeopleInControlHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompletePeopleInControlChecks_Section2_Fail(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.FailPeopleInControlChecks_PeopleInControl(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.FailPeopleInControlChecks_PeopleInControlHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteRegisterChecks_Section3(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = RegisterChecks_Section3Helpers.PassRegisterChecks_ROATP(gwApplicationOverviewPage);
            gwApplicationOverviewPage = RegisterChecks_Section3Helpers.PassRegisterChecks_RegisterOfEndPointAssessmentOrganisations(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage Fail_RegisterChecks_Section3(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = RegisterChecks_Section3Helpers.FailRegisterChecks_ROATP(gwApplicationOverviewPage);
            gwApplicationOverviewPage = RegisterChecks_Section3Helpers.FailRegisterChecks_RegisterOfEndPointAssessmentOrganisations(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteExperienceAndAccreditationChecks_Section4_NotRequired_SubContractor(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_OfficeForStudent(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_InitialTeacherTraining(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_Ofsted(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.NotRequiredExperienceAndAccreditationChecks_SubContractor(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_Subcontractos(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.NotRequiredExperienceAndAccreditationChecks_OfficeForStudents(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_InitialTeacherTraining(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_Ofsted(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.NotRequiredExperienceAndAccreditationChecks_SubContractor(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_ITT_Ofstead(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.NotRequiredExperienceAndAccreditationChecks_OFS_ITT(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.NotRequiredExperienceAndAccreditationChecks_Ofsted(gwApplicationOverviewPage);
            gwApplicationOverviewPage = ExperienceAndAccreditationChecks_Section4Helpers.PassExperienceAndAccreditationChecks_SubContractor(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteOrganisationsCriminalAndComplianceChecks_Section5(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_CompositionWithCreditors(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_WithDrawnFromContractEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_RegisterOfTrainingOrganisations(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_FudingRemovedFromAnyEducationBodies(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyProfessionalOrTradeBodies(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_ITTAccreditation(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyCharityRegister(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedDueToSafeGuardingIssues(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedDuetoWhistleBlowingIssues(gwApplicationOverviewPage);
            gwApplicationOverviewPage = OrganisationsCriminalAndComplianceChecks_Section5Helpers.PassOrganisationsCriminalAndComplianceChecks_InsolvencyOrWindingProceedings(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompletePeopleInControlCriminalAndComplianceChecks_Section6(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_UnSpentCriminalConvictions(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedForFraudOrIrregularities(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_OngoingInvestigationForFraudOrIrregularities(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_WithdrawnFromContractWithApublic(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_BreachedTaxPaymentsOrSocialSecurityContributions(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_RegisterOfRemovedTrustees(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_BeenMadeBankrupt(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_ProhibitionOrderFromTeachingRegulationAgency(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlCriminalAndComplianceChecks_Section6Helpers.PassOrganisationsCriminalAndComplianceChecks_BanFromManagementOrGovernance(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static GWApplicationOverviewPage CompleteAllSectionsWithPass_MainOrEmpRouteCompany(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1_TradingNameNotRequired(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2(gwApplicationOverviewPage);
            CompleteRegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_SubContractor(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompleteAllSectionsPass_FailPeopleInControlChecks_MainOrEmpRouteCompany(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1_TradingNameNotRequired(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2_Fail(gwApplicationOverviewPage);
            CompleteRegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_SubContractor(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompleteAllSectionsWithPass_EmployerRouteCharity(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2(gwApplicationOverviewPage);
            CompleteRegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_Subcontractos(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompleteAllSectionsPass_FailRegisterChecks_EmployerRouteCharity(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2(gwApplicationOverviewPage);
            Fail_RegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_Subcontractos(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static GWApplicationOverviewPage CompleteAllSectionsWithPass_SupportingRouteSoleTrader(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2(gwApplicationOverviewPage);
            CompleteRegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_ITT_Ofstead(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal static void ConfirmGatewayOutcomeAsPass(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.Access_Section7_ConfirmGateWayOutcome()
                 .PassThisApplicationAndContinue()
                 .YesSurePassThisApplicationAndGoToGovernance()
                 .GoToRoATPGatewayApplicationsPage();
        }
        internal static void ConfirmGatewayOutcomeAsFail(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.Access_Section7_ConfirmGateWayOutcome()
                 .FailThisApplicationAndContinue()
                 .YesSureFailThisApplicationAndGoToGovernance()
                 .GoToRoATPGatewayApplicationsPage();
        }

        internal static void ConfirmGatewayOutcomeAsReject(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.Access_Section7_ConfirmGateWayOutcome()
                 .RejectThisApplicationAndContinue()
                 .YesSureRejectThisApplicationAndGoToGovernance()
                 .GoToRoATPGatewayApplicationsPage();
        }
        internal static void ConfirmWithdrawGatewayApplication(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.SelectApplicationWithdrawl()
                .YesSureWithdrawThisApplication()
                .GoToRoATPGatewayApplicationsPage();
        }
        internal static void ConfirmRemoveGatewayApplication(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.SelectRemoveApplication()
                .YesSureRemoveThisApplication()
                .GoToRoATPGatewayApplicationsPage();
        }
        internal static void ConfirmWithdrawOutcomeMadeGatewayApplication(ReadOnlyGatewayOutcomePage readOnlyGatewayOutcomePage)
        {
            readOnlyGatewayOutcomePage.SelectApplicationWithdrawl()
                .YesSureWithdrawThisApplication()
                .GoToRoATPGatewayApplicationsPage();
        }
        internal static void ConfirmRemoveOutcomeMadeGatewayApplication(ReadOnlyGatewayOutcomePage readOnlyGatewayOutcomePage)
        {
            readOnlyGatewayOutcomePage.SelectRemoveApplication()
                .YesSureRemoveThisApplication()
                .GoToRoATPGatewayApplicationsPage();
        }
        internal static GWApplicationOverviewPage CompletePeopleInControlChecks_Section2_Clarification(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.Clarification_PeopleInControlChecks_PeopleInControl(gwApplicationOverviewPage);
            gwApplicationOverviewPage = PeopleInControlChecks_Section2Helpers.Clarification_PeopleInControlChecks_PeopleInControlHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }
        internal static void ConfirmClarification_GatewayApplication(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.SelectClarificationForOverallApplication()
                .YesClarificationRequired()
                .GoToRoATPGatewayApplicationsPage()
                .SelectInProgressTab()
                .SelectApplication();
        }
    }
}