namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class AuditDetailsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Audit details";

    private static By ReasonToDeleteCertificate => By.Id("ReasonForChange");
    private static By IncidentNumberToDeleteCertificate => By.Id("IncidentNumber");

    public AuditDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public CheckYourAnswersBeforeDeletingThisCertificatePage EnterAuditDetails()
    {
        formCompletionHelper.EnterText(ReasonToDeleteCertificate, "EAPO Entered incorrect details");
        formCompletionHelper.EnterText(IncidentNumberToDeleteCertificate, "INC-014589527");
        Continue();
        return new(context);
    }
}