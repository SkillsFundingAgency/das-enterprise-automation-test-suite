namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class NewOrgDeclarationsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Declarations";

    public NewOrgDeclarationsPage(ScenarioContext context) : base(context) => VerifyPage();

    public OrganisationApplicationOverviewPage SelectYesAndContinue()
    {
        SelectRadioOptionByText("Yes");
        Continue();
        return new OrganisationApplicationOverviewPage(context);
    }
}

