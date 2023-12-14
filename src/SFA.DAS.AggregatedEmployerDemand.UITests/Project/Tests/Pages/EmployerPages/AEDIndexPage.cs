namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class AedIndexPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "";

    #region Locators
    private static By GetHelpWithFindingATrainingProviderLink => By.LinkText("Share your interest");
    private static By ShareInterestButton => By.LinkText("Share interest");

    #endregion

    public ShareYourInterestWithTrainingProvidersPage ClickGetHelpWithFindingATrainingProviderLink() => GotoShareYourInterestWithTrainingProvidersPage(GetHelpWithFindingATrainingProviderLink);

    public ShareYourInterestWithTrainingProvidersPage ClickShareInterestButton() => GotoShareYourInterestWithTrainingProvidersPage(ShareInterestButton);

    private ShareYourInterestWithTrainingProvidersPage GotoShareYourInterestWithTrainingProvidersPage(By by)
    {
        formCompletionHelper.Click(by);
        return new ShareYourInterestWithTrainingProvidersPage(context);
    }
}
