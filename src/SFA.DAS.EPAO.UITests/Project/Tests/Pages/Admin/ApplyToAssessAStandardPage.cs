namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class ApplyToAssessAStandardPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Apply to assess a standard";

    public ApplyToAssessAStandardPage(ScenarioContext context) : base(context) => VerifyPage();

    public StandardApplicationOverviewPage SelectYesAndContinue()
    {
        SelectRadioOptionByText("Yes");
        Continue();
        return new(context);
    }
}

