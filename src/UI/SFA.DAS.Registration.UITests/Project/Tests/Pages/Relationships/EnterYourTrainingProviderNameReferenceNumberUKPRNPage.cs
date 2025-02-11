namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "name or reference number (UKPRN)";

    public AddPermissionsForTrainingProviderPage SearchForATrainingProvider(ProviderConfig providerConfig)
    {
        EnterATrainingProvider(providerConfig);

        return new AddPermissionsForTrainingProviderPage(context, providerConfig);
    }

    public AlreadyLinkedToTrainingProviderPage SearchForAnExistingTrainingProvider(ProviderConfig providerConfig)
    {
        EnterATrainingProvider(providerConfig);

        return new AlreadyLinkedToTrainingProviderPage(context);
    }

    private void EnterATrainingProvider(ProviderConfig providerConfig)
    {
        new TrainingProviderAutoCompleteHelper(context).SelectFromAutoCompleteList(providerConfig.Ukprn);

        Continue();
    }
}

public class TrainingProviderAutoCompleteHelper(ScenarioContext context) : AutoCompleteHelper(context)
{
    protected override string SearchPage => "Training provider";

    protected override By SearchTextInput => By.CssSelector("input[id='SearchTerm']");

    protected override By AutoCompleteMenu => By.CssSelector("[id='SearchTerm__listbox']");

    protected override By NthOption(int i) => By.CssSelector($"[id='SearchTerm__option--{i}']");

}
