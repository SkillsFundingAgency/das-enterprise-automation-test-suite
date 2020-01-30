using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
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

        internal ApplicationOverviewPage CompleteFinancialEvidence_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
                .ClickNoOnConsolidatedFinancialStatements()
                .ClickNoOnOtherSubsidiaryCompanies()
                .UploadFullFinancialStatementsForTwelveMonthsAndContinue()
                .VerifyYourUkUltimateParentCompany_Section3(StatusHelper.StatusCompleted);
        }
    }
}
