using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class DeliveringApprenticeshipTrainingSectionHelper
    {
        internal ApplicationOverviewPage CompleteDeliveringApprenticeshipTraining_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section7_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section7(StatusHelper.StatusCompleted);
        }
    }
}
