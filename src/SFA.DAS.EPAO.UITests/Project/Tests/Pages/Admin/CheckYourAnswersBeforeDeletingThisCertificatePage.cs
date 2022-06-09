namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class CheckYourAnswersBeforeDeletingThisCertificatePage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Check your answers before deleting this certificate";

    private static By DeleteCertificate => By.CssSelector(".govuk-button");

    public CheckYourAnswersBeforeDeletingThisCertificatePage(ScenarioContext context) : base(context) => VerifyPage();

    public YouHaveSuccessfullyDeletedPage ClickDeleteCertificateButton()
    {
        formCompletionHelper.ClickElement(DeleteCertificate);
        return new YouHaveSuccessfullyDeletedPage(context);
    }
}