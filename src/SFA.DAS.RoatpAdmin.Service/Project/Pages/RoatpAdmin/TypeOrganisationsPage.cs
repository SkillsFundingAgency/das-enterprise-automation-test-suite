namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class TypeOrganisationsPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => $"Choose a type of organisation for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Choose a type of organisation for provider";

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

    public ApplicationDateDeterminedPage SubmitOrganisationType()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs)));
        Continue();
        return new ApplicationDateDeterminedPage(context);
    }
}
