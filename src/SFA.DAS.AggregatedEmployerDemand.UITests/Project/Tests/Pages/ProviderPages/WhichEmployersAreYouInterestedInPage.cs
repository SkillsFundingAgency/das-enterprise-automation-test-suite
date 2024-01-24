namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

public class WhichEmployersAreYouInterestedInPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "";

    #region Locators
    private static By FirstEmployerCheckbox => By.CssSelector(".govuk-checkboxes__input");
    #endregion

    public EditProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckbox()
    {
        formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
        Continue();
        return new EditProvidersContactDetailsPage(context);
    }

    public FindEmployersThatNeedATrainingProviderPage BackToFindEmployersThatNeedATrainingProviderPage()
    {
        formCompletionHelper.Click(BackLink);
        return new FindEmployersThatNeedATrainingProviderPage(context);
    }
    public ConfirmProvidersContactDetailsPage CheckAndContinueWithfirstEmployerCheckboxAfterChange()
    {
        formCompletionHelper.SelectCheckbox(FirstEmployerCheckbox);
        Continue();
        return new ConfirmProvidersContactDetailsPage(context);
    }
}
