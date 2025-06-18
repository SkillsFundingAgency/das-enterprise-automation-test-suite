using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class OrganisationChecks_Section1Helpers
    {
        internal static GWApplicationOverviewPage PassOrganisationChecks_OneIn12Months(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_1ApplicationInTwelveMonths()
            .SelectPassAndContinue()
            .Verify2ApplicationIn12Months_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_LegalName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_LegalName()
            .SelectPassAndContinue()
            .VerifyLegalName_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_TradingName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_TradingName()
            .SelectPassAndContinue()
            .VerifyTradingName_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage NotRequiredOrganisationChecks_TradingName(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
           .VerifyTradingName_Section1(StatusHelper.NotRequired);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_OrganisationStatus(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_OrganisationStatus()
            .SelectPassAndContinue()
            .VerifyOrganisationStatus_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_Address(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_Address()
            .SelectPassAndContinue()
            .VerifyAddress_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_ICONumber(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_IcoRegistrationNumber()
            .SelectPassAndContinue()
            .VerifyICOregistrationnumber_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_WebsiteAddress(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_WebsiteAddress()
            .SelectPassAndContinue()
            .VerifyWebsiteaddress_Section1(StatusHelper.StatusPass);
        }
        internal static GWApplicationOverviewPage PassOrganisationChecks_OrganisationHighRisk(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section1_OrganisationHighRisk()
            .SelectPassAndContinue()
            .VerifyOrganisationhighrisk_Section1(StatusHelper.StatusPass);
        }
    }
}
