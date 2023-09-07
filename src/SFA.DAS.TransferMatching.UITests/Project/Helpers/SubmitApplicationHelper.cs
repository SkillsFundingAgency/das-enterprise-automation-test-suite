using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class SubmitApplicationHelper
    {
        public SubmitApplicationHelper() { }

        public HomePage SubmitApplication(CreateATransfersApplicationPage page, string pledgeId = "")
        {
            return GoToApprenticeshipTrainingPage(page)
                .EnterAppTrainingDetailsAndContinue()
                .VerifyStatusIsComplete()
                .GoToYourBusinessDetailsPage()
                .EnterBusinessDetailsAndContinue()
                .VerifyStatusIsComplete()
                .GoToAboutYourApprenticeshipPage()
                .EnterMoreDetailsAndContinue(pledgeId)
                .VerifyStatusIsComplete()
                .GoToContactDetailsPage()
                .EnterContactDetailsAndContinue()
                .VerifyStatusIsComplete()
                .SubmitApplication()
                .ContinueToMyAccount();
        }

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage(CreateATransfersApplicationPage page) => page.GoToApprenticeshipTrainingPage();
    }
}