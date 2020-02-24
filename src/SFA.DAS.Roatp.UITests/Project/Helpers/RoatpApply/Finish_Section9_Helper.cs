using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply
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
            return applicationOverviewPage.Access_Section9_QualityStatement()
                .SelectYesForInLineWithInstituteForApprenticeshipAndContinue()
                .VerifyQualityStatement_Section9(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteFinish_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section9_PostApplicationTasks()
                .SelectYesToCompletesAllPostApplicationTasksAndContinue()
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