namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

public class StubYouHaveSignedInEmployerPage : StubYouHaveSignedInBasePage
{
    protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

    public StubYouHaveSignedInEmployerPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context, username, idOrUserRef, newUser)
    {
        if (newUser)
        {
            idOrUserRef = new UsersSqlDataHelper(objectContext, context.Get<DbConfig>()).GetUserId(username);

            objectContext.UpdateLoginIdOrUserRef(username, idOrUserRef);

            objectContext.AddDbNameToTearDown(CleanUpDbName.EasUsersTestDataCleanUp, username);
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

    public new void Continue() => base.Continue();

}
