namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public abstract class SupportConsoleBasePage : VerifyBasePage
{
    #region Helpers and Context
    protected readonly SupportConsoleConfig config;
    #endregion

    protected static By OrganisationsMenuLink => By.LinkText("Organisations");
    protected static By CommitmentsMenuLink => By.LinkText("Commitments");
    protected static By FinanceLink => By.LinkText("Finance");
    protected static By TeamMembersLink => By.LinkText("Team members");
    private static By Heading => By.Id("no-logo");

    public SupportConsoleBasePage(ScenarioContext context) : base(context) => config = context.GetSupportConsoleConfig<SupportConsoleConfig>();

    public void ClickFinanceMenuLink() => formCompletionHelper.Click(FinanceLink);

    public SearchHomePage GoToSearchHomePage()
    {
        formCompletionHelper.ClickElement(Heading);
        return new (context);
    }
}