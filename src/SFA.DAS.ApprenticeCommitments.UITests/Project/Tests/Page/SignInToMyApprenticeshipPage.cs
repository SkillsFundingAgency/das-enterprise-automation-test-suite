using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignIntoMyApprenticeshipPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => StubSignInApprenticeAccountsPage.StubSignInPageTitle;

        public ApprenticeHomePage GoToApprenticeHomePage()
        {
            SignIn();
            return new ApprenticeHomePage(context);
        }

        public ApprenticeOverviewPage CocSignInToApprenticePortal()
        {
            SignIn();
            return new ApprenticeOverviewPage(context);
        }

        private void SignIn()
        {
            new StubSignInApprenticeAccountsPage(context).SubmitValidUserDetails(objectContext.GetApprenticeEmail(), objectContext.GetApprenticePassword()).Continue();
        }

        public CreateMyApprenticeshipAccountPage CreateAccountInStub()
        {
            new StubSignInApprenticeAccountsPage(context).CreateAccount(objectContext.GetApprenticeEmail()).Continue();

            return new CreateMyApprenticeshipAccountPage(context);
        }
    }
}
