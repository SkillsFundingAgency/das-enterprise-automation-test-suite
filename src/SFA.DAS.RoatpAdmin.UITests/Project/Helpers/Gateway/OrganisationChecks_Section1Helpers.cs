using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class OrganisationChecks_Section1Helpers
    {
        internal GWApplicationOverviewPage PassOrganisationChecks_LegalName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_LegalName()
            .SelectPassAndContinue()
            .VerifyLegalName_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_TradingName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_TradingName()
            .SelectPassAndContinue()
            .VerifyTradingName_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage NotRequiredOrganisationChecks_TradingName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
           .VerifyTradingName_Section1(StatusHelper_AdminPage.NotRequired);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_OrganisationStatus(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_OrganisationStatus()
            .SelectPassAndContinue()
            .VerifyOrganisationStatus_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_Address(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_Address()
            .SelectPassAndContinue()
            .VerifyAddress_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_ICONumber(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_IcoRegistrationNumber()
            .SelectPassAndContinue()
            .VerifyICOregistrationnumber_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_WebsiteAddress(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_WebsiteAddress()
            .SelectPassAndContinue()
            .VerifyWebsiteaddress_Section1(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationChecks_OrganisationHighRisk(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_OrganisationHighRisk()
            .SelectPassAndContinue()
            .VerifyOrganisationhighrisk_Section1(StatusHelper_AdminPage.StatusPass);
        }
    }
}
