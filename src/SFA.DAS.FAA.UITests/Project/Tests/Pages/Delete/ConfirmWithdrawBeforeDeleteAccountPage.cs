namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete
{
    public class ConfirmWithdrawBeforeDeleteAccountPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Withdraw your outstanding applications";

        public ConfirmDeleteAccountPage WithdrawBeforeDeletingMyAccount()
        {
            Continue();

            return new ConfirmDeleteAccountPage(context);
        }

    }
}
