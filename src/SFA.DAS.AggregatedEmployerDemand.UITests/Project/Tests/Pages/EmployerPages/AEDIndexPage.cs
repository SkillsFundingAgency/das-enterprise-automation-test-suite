namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class AedIndexPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "";

    #region Locators
    private static By GetHelpWithFindingATrainingProviderLink => By.LinkText("Ask if training providers can run this course");
    private static By AskCourseInformation => By.LinkText("Ask if training providers can run this course");

    #endregion

    public AskTrainingProviderForCourseInformationPage ClickGetHelpWithFindingATrainingProviderLink() => GotoShareYourInterestWithTrainingProvidersPage(GetHelpWithFindingATrainingProviderLink);

    public AskTrainingProviderForCourseInformationPage ClickShareInterestButton() => GotoShareYourInterestWithTrainingProvidersPage(AskCourseInformation);

    private AskTrainingProviderForCourseInformationPage GotoShareYourInterestWithTrainingProvidersPage(By by)
    {
        formCompletionHelper.Click(by);
        return new AskTrainingProviderForCourseInformationPage(context);
    }
}
