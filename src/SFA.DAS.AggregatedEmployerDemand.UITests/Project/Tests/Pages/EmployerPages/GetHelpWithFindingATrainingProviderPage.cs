namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class GetHelpWithFindingATrainingProviderPage : AedBasePage
{
    protected override string PageTitle => "Get help with finding a training provider";

    #region Locators
    private By NumberOfApprenticesTextBox => By.CssSelector("#NumberOfApprentices");
    private By ApprenticeshipLocationTextBox => By.CssSelector("#search-location");
    private By OrganisationNameTextBox => By.CssSelector("#OrganisationName");
    private By OrganisationEmailAddressTextBox => By.CssSelector("#ContactEmailAddress");
    #endregion

    public GetHelpWithFindingATrainingProviderPage(ScenarioContext context) : base(context) { }

    public CheckYourAnswersPage EnterValidDetails(int noOfApprentices)
    {
        formCompletionHelper.EnterText(ApprenticeshipLocationTextBox, $"{dataHelper.Location}{Keys.Enter}");
        formCompletionHelper.EnterText(OrganisationNameTextBox, AedDataHelper.OrganisationName);

        if (noOfApprentices == 0) formCompletionHelper.SelectRadioOptionByText("No");
        else
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(NumberOfApprenticesTextBox, noOfApprentices);
        }

        formCompletionHelper.EnterText(OrganisationEmailAddressTextBox, dataHelper.RandomEmail);

        Continue();

        return new CheckYourAnswersPage(context);
    }
}
