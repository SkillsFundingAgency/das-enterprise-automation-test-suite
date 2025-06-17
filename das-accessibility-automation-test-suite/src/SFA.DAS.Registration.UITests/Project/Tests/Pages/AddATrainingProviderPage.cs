namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class AddATrainingProviderPage : RegistrationBasePage
{
    protected override string PageTitle => "Add a training provider";
    protected override By ContinueButton => By.CssSelector("#submit-add-a-paye-scheme-button");

    public AddATrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

    public Relationships.EnterYourTrainingProviderNameReferenceNumberUKPRNPage AddTrainingProviderNow()
    {
        formCompletionHelper.SelectRadioOptionByText("Yes, I'll add a training provider now");
        Continue();
        return new Relationships.EnterYourTrainingProviderNameReferenceNumberUKPRNPage(context);
    }

    public EmployerAccountCreatedPage AddTrainingProviderLater()
    {
        formCompletionHelper.SelectRadioOptionByText("No, I want to finish setting up my account and add one later");
        Continue();
        return new EmployerAccountCreatedPage(context);
    }

    public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
    {
        formCompletionHelper.Click(BackLink);
        return new CreateYourEmployerAccountPage(context);
    }
}
