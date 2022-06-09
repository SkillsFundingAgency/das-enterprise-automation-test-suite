namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_ConfirmAddressPage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm where we are sending the certificate for";
    public AS_ConfirmAddressPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_CheckAndSubmitAssessmentPage ClickContinueInConfirmEmployerAddressPage()
    {
        Continue();
        return new AS_CheckAndSubmitAssessmentPage(context);
    }
}