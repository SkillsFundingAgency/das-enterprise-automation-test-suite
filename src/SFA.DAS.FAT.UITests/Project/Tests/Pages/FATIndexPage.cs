namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class FATIndexPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => "Find apprenticeship training";

    #region Locators
    private static By StartButton => By.LinkText("Start now");

    #endregion

    public FindApprenticeshipTrainingSearchPage ClickStartButton()
    {
        formCompletionHelper.Click(StartButton);
        return new FindApprenticeshipTrainingSearchPage(context);
    }
}
