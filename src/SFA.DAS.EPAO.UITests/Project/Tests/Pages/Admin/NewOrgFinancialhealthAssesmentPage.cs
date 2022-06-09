namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class NewOrgFinancialhealthAssesmentPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Financial health assessment";

    public NewOrgFinancialhealthAssesmentPage(ScenarioContext context) : base(context) => VerifyPage();

    public OrganisationApplicationOverviewPage SelectYesAndContinue()
    {
        SelectRadioOptionByText("Yes");
        Continue();
        return new(context);
    }
}

