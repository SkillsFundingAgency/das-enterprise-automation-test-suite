using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport.SqlHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubYouHaveSignedInEmployerPage : StubYouHaveSignedInBasePage
    {

        public StubYouHaveSignedInEmployerPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context, username, idOrUserRef, newUser)
        {
            if (newUser)
            {
                idOrUserRef = new UsersSqlDataHelper(objectContext, context.Get<DbConfig>()).GetUserId(username);

                objectContext.UpdateLoginIdOrUserRef(username, idOrUserRef);

                objectContext.SetOrUpdateUserCreds(username, idOrUserRef);

                objectContext.SetDbNameToTearDown(CleanUpDbName.EasUsersTestDataCleanUp, username);
            }
        }

        public MyAccountTransferFundingPage ContinueToMyAccountTransferFundingPage()
        {
            Continue();
            return new MyAccountTransferFundingPage(context);
        }

        public YourAccountsPage ContinueToYourAccountsPage()
        {
            Continue();
            return new YourAccountsPage(context);
        }

        public HomePage ContinueToHomePage()
        {
            Continue();
            return new HomePage(context);
        }

        public AccountUnavailablePage GoToAccountUnavailablePage()
        {
            Continue();
            return new AccountUnavailablePage(context);
        }

        public StubAddYourUserDetailsPage ContinueToStubAddYourUserDetailsPage()
        {
            Continue();
            return new StubAddYourUserDetailsPage(context);
        }

        public CreateYourEmployerAccountPage ContinueToCreateYourEmployerAccountPage()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }

        public new void Continue() => base.Continue();

    }
}
