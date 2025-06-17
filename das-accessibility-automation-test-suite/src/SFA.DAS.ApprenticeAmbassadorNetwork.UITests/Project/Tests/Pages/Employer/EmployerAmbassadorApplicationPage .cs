namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class EmployerAmbassadorApplicationPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Join the Apprentice Ambassador Network as an employer";

    private static By StartButton => By.Id("start-now");

    public TermsAndConditionsOfEmployerPage StartEmployerAmbassadorApplication()
    {
        formCompletionHelper.Click(StartButton);
        return new TermsAndConditionsOfEmployerPage(context);
    }
}
