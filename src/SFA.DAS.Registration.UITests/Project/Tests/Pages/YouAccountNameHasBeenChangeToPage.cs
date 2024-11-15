namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YouAccountNameHasBeenChangeToPage : RegistrationBasePage
{
    private string NewAccountName { get; set; }

    protected override string PageTitle => $"Your account name has been changed to {NewAccountName}";
    protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

    public YouAccountNameHasBeenChangeToPage(ScenarioContext context, string newAccountName) : base(context)
    {
        NewAccountName = newAccountName;
        VerifyPage();
    }

    public CreateYourEmployerAccountPage ContinueToCreateYourEmployerAccountPage()
    {
        Continue();
        return new CreateYourEmployerAccountPage(context);
    }
}