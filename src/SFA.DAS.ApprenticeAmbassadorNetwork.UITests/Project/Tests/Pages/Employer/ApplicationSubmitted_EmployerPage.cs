using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class ApplicationSubmitted_EmployerPage : AanBasePage
{
    protected override string PageTitle => "Application submitted";

    private By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

    public ApplicationSubmitted_EmployerPage(ScenarioContext context) : base(context) => VerifyPage();

    public Employer_NetworkHubPage ContinueToAmbassadorHub()
    {
        //formCompletionHelper.Click(NetworkHubLink);
        Continue();

        return new Employer_NetworkHubPage(context);
    }
}