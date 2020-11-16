using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class FinancialEvidence_Section2_Helper
    {
        internal ApplicationOverviewPage CompleteFinancialEvidence_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_IntroductionWhatYouwillNeed()
                .ContinueOnFinancialHealthAssessment()
                .VerifyIntroductionStatus_Section2(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_YourOrganisationsFinancialEvidence()
                .SelectYesOnAnnualTurnOverAndContinue()
                .SelectNoOnFundingFromEsfaAndContinue()
                .EnterInputsForFinancialEvidenceAndContinue()
                .SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
                .ClickYesForFinancialStatementsCoveringAnyPeriodAndContinue()
                .ContinueOnWhatYouNeedToUploadForFinancialStatementsAndManagementAccounts()
                .UploadFinancialFileAndContinue()
                .UploadManagementAccountsFileAndContinue()
                .SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
                .VerifyYourOrganisationsFinancialEvidence_Section2(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_2_ForSupportingRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_YourOrganisationsFinancialEvidence()
                .SelectYesOnAnnualTurnOverAndContinue()
                .SelectNoOnFundingFromEsfaAndContinue()
                .EnterInputsForFinancialEvidenceAndContinue()
                .SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
                .SelectNoForFinancialStatementsCoveringAnyPeriod_SupportingAndContinue()
                .SelectNoForManagementAccountsSupportingRouteAndContinue()
                .ContinueOnWhatYouNeedToUploadForManagementAccountsCoveringThreeMonths()
                .UploadManagementAccountsAndContinue()
                .UploadFinancialProjectionsAndContinue()
                .SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
                .VerifyYourOrganisationsFinancialEvidence_Section2(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_2_ForNoUltimateParentCompany(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_YourOrganisationsFinancialEvidence()
                .SelectYesOnAnnualTurnOverAndContinue()
                .SelectNoOnFundingFromEsfaAndContinue()
                .EnterInputsForFinancialEvidenceAndContinue()
                .SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
                .ClickNoForFinancialStatementsCoveringAnyPeriodAndContinue()
                .ContinueOnWhatYouNeedToUploadForManagementAccounts()
                .UploadManagementAccountsFileAndContinue()
                .SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
                .VerifyYourOrganisationsFinancialEvidence_Section2(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
                .ClickNoOnConsolidatedFinancialStatements()
                .ClickNoOnOtherSubsidiaryCompanies()
                .UploadFullFinancialStatementsForTwelveMonthsAndContinue()
                .VerifyYourUkUltimateParentCompany_Section3(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage VerifyFinancialEvidenceSectionExempted(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .VerifyIntroductionStatus_Section2(StatusHelper.NotRequired)
                .VerifyYourOrganisationsFinancialEvidence_Section2(StatusHelper.NotRequired)
                .VerifyYourUkUltimateParentCompany_Section3(StatusHelper.NotRequired);
        }
    }
}
