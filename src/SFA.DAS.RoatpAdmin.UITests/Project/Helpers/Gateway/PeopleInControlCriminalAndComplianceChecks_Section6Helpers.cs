using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class PeopleInControlCriminalAndComplianceChecks_Section6Helpers
    {
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_UnSpentCriminalConvictions(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_UnspentCriminalConvictions()
            .SelectPassAndContinue()
            .VerifyUnspentcriminalconvictions_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_FailedToPayBackFunds()
            .SelectPassAndContinue()
            .VerifyFailedtopaybackfunds_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_InvestigatedForFraudOrIrregularities(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_InvestigatedForFraudorIrregularities()
            .SelectPassAndContinue()
            .VerifyInvestigatedforfraudorirregularities_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_OngoingInvestigationForFraudOrIrregularities(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_OngoingInvestigationsForFraudorIrregularities()
            .SelectPassAndContinue()
            .VerifyOngoinginvestigationsforfraudorirregularities_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_ContractTerminateEarlyByPublicBody()
            .SelectPassAndContinue()
            .VerifyContractterminatedearlybyapublicbody_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_WithdrawnFromContractWithApublic(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_WithdrawnFromContractWithPublicBody()
            .SelectPassAndContinue()
            .VerifyWithdrawnfromacontractwithapublicbody_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_BreachedTaxPaymentsOrSocialSecurityContributions(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_BreachedTaxPaymentsOrSocialSecurityPayments()
            .SelectPassAndContinue()
            .VerifyBreachedtaxpaymentsorsocialsecuritycontributions_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_RegisterOfRemovedTrustees(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_RegisterOfRemovedTrustees()
            .SelectPassAndContinue()
            .VerifyBreachedtaxpaymentsorsocialsecuritycontributions_Section6(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_BeenMadeBankrupt(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section6_BeenMadeBankrupt()
            .SelectPassAndContinue()
            .VerifyBeenmadebankrupt_Section6(StatusHelper_AdminPage.StatusPass);
        }
    }
}
