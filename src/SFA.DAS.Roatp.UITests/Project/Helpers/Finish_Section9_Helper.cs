using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class Finish_Section9_Helper
    {
        internal ApplicationOverviewPage CompleteFinish_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_ApplicationPermissionChecks()
                .SelectYesForPermissionsAndContinue()
                .SelectYesCheckedWithEveryoneAndContinue()
                .SelectYesForPermissionFromOrganisationAndContinue()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteFinish_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_CommercialInConfidenceInformation()
                .SelectYesForCommercialInConfidenceInformationAndContinue()
                .VerifyCommercialInformation_Section9(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteFinish_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_TermsAndConditions()
                .SelectYesAgreeTermsAndContionsOfSubmittingAnApplicataionAndContinue()
                .SelectYesAgreeTermsAndContionsOfJoiingRoatpAndContinue()
                .VerifyTermsAndConditions_Section9(StatusHelper.StatusCompleted);
        }
        internal ApplicationSubmittedPage CompleteFinish_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_SubmitApplication()
                .ConfirmAllAnswersAndSubmitApplication()
                .SetApplicationReference();
        }
    }
}
