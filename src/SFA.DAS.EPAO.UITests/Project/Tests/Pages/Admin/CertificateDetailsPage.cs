namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class CertificateDetailsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Certificate";

    #region Helpers and Context
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
    private static By DeleteCertificateLink => By.LinkText("Delete certificate");
    private static By AmendCertificateLink => By.LinkText("Amend certificate information");
    private static By ReprintCertificateLink => By.LinkText("Request certificate reprint");
    private static By ShowAllHistoryButton => By.LinkText("Show all history");
    #endregion

    public CertificateDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AreYouSureYouWantToDeletePage ClickDeleteCertificateLink()
    {
        formCompletionHelper.ClickElement(DeleteCertificateLink);
        return new AreYouSureYouWantToDeletePage(context);
    }

    public AmendReasonPage ClickAmendCertificateLink()
    {
        formCompletionHelper.ClickElement(AmendCertificateLink);
        return new AmendReasonPage(context);
    }

    public ReprintReasonPage ClickReprintCertificateLink()
    {
        formCompletionHelper.ClickElement(ReprintCertificateLink);
        return new ReprintReasonPage(context);
    }

    public CertificateDetailsPage ClickShowAllHistory()
    {
        formCompletionHelper.ClickElement(ShowAllHistoryButton);
        return new CertificateDetailsPage(context);
    }

    public CertificateDetailsPage VerifyActionHistoryItem(int logIndex, string action)
    {
        var by = By.CssSelector($".govuk-table__row:nth-child({logIndex}) td[data-label='Action']");
        pageInteractionHelper.VerifyText(by, action);
        return this;
    }

    public CertificateDetailsPage VerifyIncidentNumber(int logIndex, string incidentNumber)
    {
        var by = By.CssSelector($".govuk-table__row:nth-child({logIndex}) td[data-label='Change'] p:nth-child(2)");
        pageInteractionHelper.VerifyText(by, incidentNumber);
        return this;
    }

    public CertificateDetailsPage VerifyFirstReason(int logIndex, string reason)
    {
        var by = By.CssSelector($".govuk-table__row:nth-child({logIndex}) td[data-label='Change'] li");
        pageInteractionHelper.VerifyText(by, reason);
        return this;
    }
}