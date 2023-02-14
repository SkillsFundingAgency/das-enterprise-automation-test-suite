namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public abstract class RoatpAdminBasePage : VerifyBasePage
{
    protected override By PageHeader => By.TagName("h1");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    protected static By RadioInputs => By.CssSelector(".govuk-radios__input");

    public RoatpAdminBasePage(ScenarioContext context) : base(context) => VerifyPage();

    protected void Back() => formCompletionHelper.ClickLinkByText("Back");
}
