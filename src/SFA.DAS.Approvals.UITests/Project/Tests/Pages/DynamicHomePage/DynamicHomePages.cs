using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DynamicHomePages(ScenarioContext context, bool navigate = false) : HomePage(context, navigate)
    {
        private static By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");
        private static By VerifyDraftStatus => By.Id("draft");
        private static By VerifyWithTrainingProviderStatus => By.Id("with-training-provider");
        private static By VerifyReadyToReviewStatus => By.Id("ready-for-review");
        private static By ReviewApprenticeDetailsButton => By.LinkText("Review apprentice details");
        private static By ViewApprenticeDetailsLink => By.LinkText("View apprentice details");
        private static By DynamicHomeContinueButton => By.LinkText("Continue");

        public DoYouKnowWhichCourseYourApprenticeWillTakePage StartNowToReserveFunding()
        {
            formCompletionHelper.ClickElement(StartNowButton);
            return new DoYouKnowWhichCourseYourApprenticeWillTakePage(context);
        }
        public EditApprenticeDetailsPage CheckDraftStatusAndAddDetails()
        {
            pageInteractionHelper.VerifyText(VerifyDraftStatus, "DRAFT");
            formCompletionHelper.Click(DynamicHomeContinueButton);
            return new EditApprenticeDetailsPage(context);
        }
        public DynamicHomePages CheckWithTrainingProviderStatus()
        {
            pageInteractionHelper.VerifyText(VerifyWithTrainingProviderStatus, "WITH TRAINING PROVIDER");
            return new DynamicHomePages(context);
        }
        public AfterEditApproveApprenticeDetailsPage CheckReadyToReviewStatus()
        {
            pageInteractionHelper.VerifyText(VerifyReadyToReviewStatus, "READY TO REVIEW");
            formCompletionHelper.Click(ReviewApprenticeDetailsButton);
            return new AfterEditApproveApprenticeDetailsPage(context);
        }

        public DynamicHomePages VerifyViewApprenticeDetailsLink()
        {
            VerifyPageAfterRefresh(ViewApprenticeDetailsLink, "View apprentice details");

            return new DynamicHomePages(context);
        }

        public DynamicHomePages VerifyReserveFundingPanel()
        {
            pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, "Continue setting up an apprenticeship");
            return this;
        }
    }
}