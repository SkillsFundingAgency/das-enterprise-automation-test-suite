using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class EmailAndPasswordSuccessfulBasePage : ApprenticeCommitmentsBasePage
    {
        public EmailAndPasswordSuccessfulBasePage(ScenarioContext context) : base(context, verifyserviceheader: false) { }

        public ApprenticeHomePage ReturnToHome()
        {
            ClickOnRetunToHomeLink();
            return new ApprenticeHomePage(context, false);
        }

        public CreateMyApprenticeshipAccountPage ReturnToCreateMyApprenticeshipAccountPage()
        {
            ClickOnRetunToHomeLink();
            return new CreateMyApprenticeshipAccountPage(context);
        }

        private void ClickOnRetunToHomeLink() => formCompletionHelper.ClickLinkByText("Return to home");
    }
}
