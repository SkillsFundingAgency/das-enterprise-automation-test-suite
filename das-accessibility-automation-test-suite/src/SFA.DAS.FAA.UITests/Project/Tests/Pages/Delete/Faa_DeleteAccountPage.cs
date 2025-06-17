namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

public class DeleteAccountPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Delete your Find an apprenticeship account";

    public ConfirmDeleteAccountPage ContinueDeleteMyAccount()
    {
        Continue();

        return new ConfirmDeleteAccountPage(context);
    }
    public ConfirmWithdrawBeforeDeleteAccountPage ContinueToDeleteMyAccounWithApplication()
    {
        Continue();

        return new ConfirmWithdrawBeforeDeleteAccountPage(context);
    }
}
