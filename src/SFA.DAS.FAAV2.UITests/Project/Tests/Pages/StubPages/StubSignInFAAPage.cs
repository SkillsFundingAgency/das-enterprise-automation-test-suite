namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.StubPages;

public class StubSignInFAAPage(ScenarioContext context) : StubSignInBasePage(context)
{
    protected override string PageTitle => StubSignInFAAPageTitle;

    internal static string StubSignInFAAPageTitle => "Stub Authentication - Enter sign in details";

    private static By MobilePhoneInput => By.CssSelector(".govuk-input[id='MobilePhone']");

    public StubYouHaveSignedInFAAPage SubmitValidUserDetails(FAAPortalUser loginUser)
    {
        return GoToStubYouHaveSignedInFAAPage(loginUser.Username, loginUser.IdOrUserRef, loginUser.MobilePhone, false);
    }

    public StubYouHaveSignedInFAAPage CreateAccount(string email) => GoToStubYouHaveSignedInFAAPage(email, email, "0", true);

    private StubYouHaveSignedInFAAPage GoToStubYouHaveSignedInFAAPage(string email, string idOrUserRef, string mobilePhone, bool newUser)
    {
        EnterLoginDetails(email, idOrUserRef);

        formCompletionHelper.EnterText(MobilePhoneInput, mobilePhone);

        ClickSignIn();

        return new StubYouHaveSignedInFAAPage(context, email, idOrUserRef, newUser);
    }
}
