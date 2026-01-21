namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class TypeOrganisationsPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => $"Choose the type of organisation for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Choose the type of organisation for provider";

    protected override By ContinueButton => By.Id("continue");

    public ConfirmDetailsPage SubmitOrganisationType()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs)));
        Continue();
        return new ConfirmDetailsPage(context);
    }

}
