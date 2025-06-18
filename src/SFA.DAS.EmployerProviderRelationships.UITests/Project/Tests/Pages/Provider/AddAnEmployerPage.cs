namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class AddAnEmployerPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    private static By StartNowButton => By.CssSelector(".govuk-button--start");

    protected override string PageTitle => "Add an employer";

    private static By FirstName => By.CssSelector("input#FirstName");

    private static By LastName => By.CssSelector("input#LastName");

    public SearchEmployerEmailPage StartNowToAddAnEmployer()
    {
        formCompletionHelper.Click(StartNowButton);

        return new(context);
    }

    public CheckEmployerDetailsPage SubmitEmployerName()
    {
        formCompletionHelper.EnterText(FirstName, eprDataHelper.EmployerFirstName);

        formCompletionHelper.EnterText(LastName, eprDataHelper.EmployerLastName);

        Continue();

        return new(context);
    }

    public CheckEmployerDetailsPage ChangeEmployerName()
    {
        formCompletionHelper.EnterText(FirstName, eprDataHelper.EmployerFirstName);

        formCompletionHelper.EnterText(LastName, eprDataHelper.EmployerLastName);

        Continue();

        return new(context);
    }
}
