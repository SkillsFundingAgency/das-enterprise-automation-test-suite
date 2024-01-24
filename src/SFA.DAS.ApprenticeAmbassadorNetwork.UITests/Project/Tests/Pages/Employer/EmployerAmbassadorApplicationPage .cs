namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class EmployerAmbassadorApplicationPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Register to become an employer ambassador for";

    private static By StartButton => By.Id("start-now");

    public TermsAndConditionsOfEmployerPage StartEmployerAmbassadorApplication()
    {
        formCompletionHelper.Click(StartButton);
        return new TermsAndConditionsOfEmployerPage(context);
    }
}
