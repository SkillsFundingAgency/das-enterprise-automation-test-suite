namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public class AreYouSureYouDoNotWantToAddPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
{
    protected override By ContinueButton => By.CssSelector("button[id='confirm'][type='submit']");

    protected override string PageTitle => $"Are you sure you do not want to add";

    public TrainingProvidertNotAddedPage ConfirmDeclineRequest()
    {
        Continue();

        return new(context);
    }
}
