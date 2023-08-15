namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class EmployerSearchPage : AanBasePage
{
    protected override string PageTitle => "Search for your employer's name or address";

    private static By FirstAddress => By.Id("SearchTerm__option--0");

    private static By PostCodeField = By.Id("SearchTerm");

    public EmployerSearchPage(ScenarioContext context) : base(context) => VerifyPage();

    public EmployerDetailsPage EnterPostcodeAndContinue()
    {
        formCompletionHelper.EnterText(PostCodeField, aanDataHelpers.PostCode);
        formCompletionHelper.Click(FirstAddress);
        Continue();
        return new EmployerDetailsPage(context);
    }
}



