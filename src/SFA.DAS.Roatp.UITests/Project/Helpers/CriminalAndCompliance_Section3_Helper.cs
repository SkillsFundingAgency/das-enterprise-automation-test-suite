using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class CriminalAndCompliance_Section3_Helper
    {
        internal ApplicationOverviewPage CompleteCriminalAndCompliance_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .Access_Section3_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section3(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteCriminalAndCompliance_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section3_ChecksOnYourOrganisation()
                .SelectYesForCompositionWithCreditorsAndContinue()
                .SelectYesEnterInformationForFailedToPayFundsAndContinue()
                .SelectYesAndEnterInformationForContractTerminatedByPublicBodyAndContinue()
                .SelectNoForWithdrawnFromAContractWithRoTo()
                .SelectYesEnterInformationForContractWithdrawnWithPublicBody()
                .SelectYesEnterInformationForFundingRemovedFromEducationBodiesAndContinue()
                .SelectYesEnterInformationForFundingRemovedFromEducationBodies()
                .SelectYesEnterInformationForWithdrawlfromITTAccreditationAndContinue()
                .SelectYesAndEnterInformationForRemovedFromCharityRegister()
                .SelectYesEnterInformationForInvestigatedDueToSafeGuardingIssuesAndContinue()
                .SelectYesEnterInformationForInvestigatedDueToWhistleBlowingAndContinue()
                .SelectYesEnterInformationForSubjectToInsolvencyOrWindingUpProceedingsAndContinue()
                .VerifyChecksOnYourOrganisations_Section3(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteCriminalAndCompliance_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section3_IntroductionWhatYouWillNeedStatusWhosInControl()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatusControl_Section3(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteCriminalAndCompliance_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section3_ChecksOnWhosInControlOfYourOrganisation()
                .SelectYesEnterInformationForUnspentCriminalConvicitionAndContinue()
                .SelectYesEnterInformationForFailedToPayBackFundAndContinue()
                .SelectYesEnterInformationForFraudOrIrregularities()
                .SelectYesEnterInformationForOngoingInvestigationForFraudAndContinue()
                .SelectYesEnterInformationForContractTerminatedByPublicBodyAndContinue()
                .SelectYesEnterInformationForContractWithdrawnWithPublicBodyAndContinue()
                .SelectYesEnterInformationForBreachingTaxandSocialSecurityContributionsAndContinue()
                .SelectYesEnterInformationForBankruptAndContinue()
                .VerifyCheckWhoIsInControl_Section3(StatusHelper.StatusCompleted);
        }
    }
}
