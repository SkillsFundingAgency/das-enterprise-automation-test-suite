namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class SetYourEmployerAccountNamePage : RegistrationBasePage
{
    protected override string PageTitle => "Set your account name";
    protected override By ContinueButton => By.CssSelector("#accept");
    protected static By NewNameTextBox => By.Id("NewName");

    public SetYourEmployerAccountNamePage(ScenarioContext context) : base(context) => VerifyPage();

    public YourAccountNameHasBeenChangedPage SelectoptionToSkipNameChange()
    {
        formCompletionHelper.SelectRadioOptionByText("No, I don't need to change my account name");
        Continue();
        return new YourAccountNameHasBeenChangedPage(context);
    }

    public ConfirmYourNewAccountNamePage SelectoptionToChangeAccountName(string newAccountName)
    {
        formCompletionHelper.SelectRadioOptionByText("Yes, I want to change my account name");

        formCompletionHelper.EnterText(NewNameTextBox, newAccountName);

        objectContext.UpdateOrganisationName(newAccountName);

        Continue();

        return new ConfirmYourNewAccountNamePage(context);
    }

    public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
    {
        formCompletionHelper.Click(BackLink);
        return new CreateYourEmployerAccountPage(context);
    }
}
