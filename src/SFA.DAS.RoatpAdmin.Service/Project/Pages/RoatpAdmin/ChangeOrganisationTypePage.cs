namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeOrganisationTypePage : ChangeBasePage
{
    protected override string PageTitle => $"Change organisation type for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change organisation type for provider";

    public ChangeOrganisationTypePage(ScenarioContext context) : base(context) { }

    public ResultsFoundPage ConfirmNewOrganisationType()
    {
        formCompletionHelper.ClickElement(() =>
        {
            var randomElement = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs));
            objectContext.UpdateOrganisationType(randomElement?.Text);
            return randomElement;
        });

        Continue();

        return new ResultsFoundPage(context);
    }
}
