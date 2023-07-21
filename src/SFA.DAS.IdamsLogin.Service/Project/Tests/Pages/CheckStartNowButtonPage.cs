namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class CheckStartNowButtonPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => "Apprenticeship service employer support tool";

    protected override By Identifier => IdamsPageSelector.StartNowButton;

    public CheckStartNowButtonPage(ScenarioContext context) : base(context) { }

    public void ClickStartNowButton() => formCompletionHelper.Click(Identifier);
}
