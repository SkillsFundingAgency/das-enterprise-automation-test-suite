namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class SupportToolLandingPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => "Apprenticeship service employer support tool";

    protected override By Identifier => IdamsPageSelector.StartNowButton;

    public SupportToolLandingPage(ScenarioContext context) : base(context) { }

    public void ClickStartNowButton() => formCompletionHelper.Click(Identifier);
}
