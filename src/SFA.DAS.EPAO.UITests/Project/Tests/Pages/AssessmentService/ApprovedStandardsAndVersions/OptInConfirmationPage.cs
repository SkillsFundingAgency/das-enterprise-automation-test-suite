namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApprovedStandardsAndVersions;

public class OptInConfirmationPage : EPAO_BasePage
{
    protected override string PageTitle => "You've opted in to version";

    public OptInConfirmationPage(ScenarioContext context) : base(context) => VerifyPage();
}