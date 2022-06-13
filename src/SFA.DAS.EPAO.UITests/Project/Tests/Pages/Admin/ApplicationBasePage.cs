namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public abstract class ApplicationBasePage : EPAOAdmin_BasePage
{
    protected static By NewTab => By.CssSelector("#tab_new");
    protected static By InProgressTab => By.CssSelector("#tab_in-progress");
    protected static By FeedbackTab => By.CssSelector("#tab_feedback");
    protected static By ApprovedTab => By.CssSelector("#tab_approved");

    public ApplicationBasePage(ScenarioContext context) : base(context) => VerifyPage();

    public new StaffDashboardPage ReturnToDashboard() => base.ReturnToDashboard();

    protected void GoToApplicationOverviewPage(By by)
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));
        formCompletionHelper.ClickLinkByText(objectContext.GetApplyOrganisationName());
    }
}