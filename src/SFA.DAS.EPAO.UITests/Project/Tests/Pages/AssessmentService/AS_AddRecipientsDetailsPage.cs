namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_AddRecipientsDetailsPage : EPAOAssesment_BasePage
{
    protected override string PageTitle => "Add recipient's details";

    private static By RecipientsNameTextBox => By.Id("Name");

    public AS_AddRecipientsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmAddressPage AddRecipientAndContinue()
    {
        formCompletionHelper.EnterText(RecipientsNameTextBox, "Tesco");
        Continue();
        return new(context);
    }
}
