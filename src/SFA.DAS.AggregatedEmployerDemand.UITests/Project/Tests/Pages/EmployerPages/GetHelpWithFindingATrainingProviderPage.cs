namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class GetHelpWithFindingATrainingProviderPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Get help with finding a training provider";

    #region Locators
    private static By NumberOfApprenticesTextBox => By.CssSelector("#NumberOfApprentices");
    private static By ApprenticeshipLocationTextBox => By.CssSelector("#search-location");
    private static By OrganisationNameTextBox => By.CssSelector("#OrganisationName");
    private static By OrganisationEmailAddressTextBox => By.CssSelector("#ContactEmailAddress");

    #endregion

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

        formCompletionHelper.EnterText(OrganisationEmailAddressTextBox, dataHelper.Email);

        Continue();

        return new CheckYourAnswersPage(context);
    }
}
