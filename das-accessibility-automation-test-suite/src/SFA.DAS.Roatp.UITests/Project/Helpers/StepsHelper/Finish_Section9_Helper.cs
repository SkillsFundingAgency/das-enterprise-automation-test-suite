using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class Finish_Section9_Helper
    {
        internal static ApplicationOverviewPage CompleteFinish_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_ApplicationPermissionChecks()
                .SelectYesForPermissionsAndContinue()
                .SelectYesCheckedWithEveryoneAndContinue()
                .SelectYesForPermissionFromOrganisationAndContinue()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteFinish_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_QualityStatement()
                .SelectYesForInLineWithInstituteForApprenticeshipAndContinue()
                .VerifyQualityStatement_Section9(StatusHelper.StatusCompleted);
        }

        internal static ApplicationOverviewPage CompleteFinish_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_PostApplicationTasks()
                .SelectYesToCompletesAllPostApplicationTasksAndContinue()
                .VerifyTermsAndConditions_Section9(StatusHelper.StatusCompleted);
        }

        internal static ApplicationSubmittedPage CompleteFinish_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_SubmitApplication()
                .ConfirmAllAnswersAndSubmitApplication()
                .SetApplicationReference();
        }

        internal static ApplicationOverviewPage UnhappyPathFinish_123(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_ApplicationPermissionChecks()
                .SelectNoForPermissionsAndContinue()
                .ReturnToApplicationOverview()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusInProgress)
                .Access_Section9_ApplicationPermissionChecks()
                .SelectYesForPermissionsAndContinue()
                .SelectNoCheckedWithEveryoneAndContinue()
                .ReturnToApplicationOverview()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusInProgress)
                .Access_Section9_ApplicationPermissionChecks()
                .SelectYesForPermissionsAndContinue()
                .SelectYesCheckedWithEveryoneAndContinue()
                .SelectNoForPermissionFromOrganisationAndContinue()
                .ReturnToApplicationOverview()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusInProgress)
                .Access_Section9_ApplicationPermissionChecks()
                .SelectYesForPermissionsAndContinue()
                .SelectYesCheckedWithEveryoneAndContinue()
                .SelectYesForPermissionFromOrganisationAndContinue()
                .VerifyApplicationPermissions_Section9(StatusHelper.StatusCompleted)
                .Access_Section9_QualityStatement()
                .SelectNoForInLineWithInstituteForApprenticeshipAndContinue()
                .ReturnToApplicationOverview()
                .VerifyQualityStatement_Section9(StatusHelper.StatusInProgress)
                .Access_Section9_QualityStatement()
                .SelectYesForInLineWithInstituteForApprenticeshipAndContinue()
                .VerifyQualityStatement_Section9(StatusHelper.StatusCompleted)
                .Access_Section9_PostApplicationTasks()
                .SelectNoToCompletesAllPostApplicationTasksAndContinue()
                .ReturnToApplicationOverview()
                .VerifyTermsAndConditions_Section9(StatusHelper.StatusInProgress);
        }
    }
}