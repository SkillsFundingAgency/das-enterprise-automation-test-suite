namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ApplicationDateDeterminedPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "What is the application determined date for this organisation?";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    private static By Day => By.CssSelector("#Day");

    private static By Month => By.CssSelector("#Month");

    private static By Year => By.CssSelector("#Year");

    public ConfirmDetailsPage EnterDob()
    {
        formCompletionHelper.EnterText(Day, 30);
        formCompletionHelper.EnterText(Month, 11);
        formCompletionHelper.EnterText(Year, 1980);
        Continue();
        return new ConfirmDetailsPage(context);
    }

}
