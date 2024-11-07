namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

public class ConfirmDeleteAccountPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Confirm your account deletion";

    private static By EmailAddress => By.CssSelector("#Email");

    private static By DeleteMyAccount => By.CssSelector(".govuk-button.govuk-button--warning");

    public FAASignedOutLandingpage ConfirmDeleteMyAccount()
    {
        formCompletionHelper.EnterText(EmailAddress, fAAUserNameDataHelper.FaaNewUserEmail);

        formCompletionHelper.Click(DeleteMyAccount);

        return new FAASignedOutLandingpage(context);
    }
}
