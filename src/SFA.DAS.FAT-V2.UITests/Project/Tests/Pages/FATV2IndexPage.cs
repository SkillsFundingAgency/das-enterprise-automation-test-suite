namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class FATV2IndexPage(ScenarioContext context) : FATV2BasePage(context)
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
