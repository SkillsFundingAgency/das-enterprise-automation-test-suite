namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApprovedStandardsAndVersions;

public class ConfirmOptInForAssociateProjectManagerPage : EPAO_BasePage
{
    protected override string PageTitle => "Associate project manager";

    public ConfirmOptInForAssociateProjectManagerPage(ScenarioContext context) : base(context) => VerifyPage();

    public OptInConfirmationPage ConfirmOptIn()
    {
        Continue();
        return new(context);
    }
}