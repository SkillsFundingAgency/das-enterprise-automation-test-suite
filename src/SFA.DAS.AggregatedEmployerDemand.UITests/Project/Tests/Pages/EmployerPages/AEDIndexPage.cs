using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class AedIndexPage : AedBasePage
{
    protected override string PageTitle => "";

    public AedIndexPage(ScenarioContext context) : base(context) { }

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
