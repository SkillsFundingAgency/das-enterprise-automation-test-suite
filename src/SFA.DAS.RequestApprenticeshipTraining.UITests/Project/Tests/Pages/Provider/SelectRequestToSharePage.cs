namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class SelectRequestToSharePage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Select requests to share your information";

    public SelectProviderEmailToSharePage SelectRequest()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(By.CssSelector($"input.govuk-checkboxes__input[value='{ratDataHelper.RequestId}'][type='checkbox']")));

        Continue();

        return new(context);
    }
}
