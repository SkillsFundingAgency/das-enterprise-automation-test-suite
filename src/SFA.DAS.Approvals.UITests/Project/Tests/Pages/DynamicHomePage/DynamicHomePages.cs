using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DynamicHomePages : HomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private string VerifyDraftStatusMessage => "DRAFT";
        private string VerifyWithTrainingProviderStatusMessage => "WITH TRAINING PROVIDER";
        private string VerifyReadyToReviewStatusMessage => "READY TO REVIEW";
        private string VerifyViewApprenticeDetails => "View apprentice details";

        protected By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");
        private By VerifyDraftStatus => By.Id("draft");
        private By VerifyWithTrainingProviderStatus => By.Id("with-training-provider");
        private By VerifyReadyToReviewStatus => By.Id("ready-for-review");
        private By ReviewApprenticeDetailsButton => By.LinkText("Review apprentice details");
        private By VerifyViewApprenticeDetailsLink => By.LinkText("View apprentice details");
        private By DynamicHomeContinueButton => By.LinkText("Continue");

        public DynamicHomePages(ScenarioContext context, bool navigate = false) : base(context, navigate) => _context = context;

        public DoYouKnowWhichCourseYourApprenticeWillTakePage StartNowToReserveFunding()
        {
            formCompletionHelper.ClickElement(StartNowButton);
            return new DoYouKnowWhichCourseYourApprenticeWillTakePage(_context);
        }
        public EditApprenticePage CheckDraftStatusAndAddDetails()
        {
            pageInteractionHelper.VerifyText(VerifyDraftStatus, VerifyDraftStatusMessage);
            formCompletionHelper.Click(DynamicHomeContinueButton);
            return new EditApprenticePage(_context);
        }
        public DynamicHomePages CheckWithTrainingProviderStatus()
        {
            pageInteractionHelper.VerifyText(VerifyWithTrainingProviderStatus, VerifyWithTrainingProviderStatusMessage);
            return  new DynamicHomePages(_context);
        }
        public AfterEditApproveApprenticeDetailsPage CheckReadyToReviewStatus()
        {
            pageInteractionHelper.VerifyText(VerifyReadyToReviewStatus, VerifyReadyToReviewStatusMessage);
            formCompletionHelper.Click(ReviewApprenticeDetailsButton);
            return new AfterEditApproveApprenticeDetailsPage(_context);
        }
        public DynamicHomePages VerifyYourFundingReservationsLink()
        {
            pageInteractionHelper.VerifyText(VerifyViewApprenticeDetailsLink, VerifyViewApprenticeDetails);
            return new DynamicHomePages(_context);
        }

        public DynamicHomePages VerifyReserveFundingPanel()
        {
            base.pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, "Continue setting up an apprenticeship");
            return this;
        }
    }
}