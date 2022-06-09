namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class CertificateAddressPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => $"{PageTitlePrefix} the address that you'd like us to send the certificate to";

    private string PageTitlePrefix { get; set; }

    #region Helpers and Context
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
    private static By CertificateRecipientName => By.Id("Name");
    private static By CertificateEmployerName => By.Id("Employer");
    private static By CertificateAddresLine1 => By.Id("AddressLine1");
    private static By CertificateAddresLine2 => By.Id("AddressLine2");
    private static By CertificateAddresLine3 => By.Id("AddressLine3");
    private static By CertificateCity => By.Id("City");
    private static By CertificatePostcode => By.Id("Postcode");
    private static By CertificateReasonForChange => By.Id("ReasonForChange");
    #endregion

    public CertificateAddressPage(ScenarioContext context, string pageTitlePrefix) : base(context)
    {
        PageTitlePrefix = pageTitlePrefix;
        VerifyPage();
    }

    public CertificateAddressPage EnterRecipientName(string recipientName)
    {
        EnterText(CertificateRecipientName, recipientName);
        return this;
    }

    public CertificateAddressPage EnterEmployerName(string employer)
    {
        EnterText(CertificateEmployerName, employer);
        return this;
    }

    public CertificateAddressPage EnterAddress()
    {
        EnterText(CertificateAddresLine1, EPAODataHelper.AddressLine1);
        EnterText(CertificateAddresLine2, EPAODataHelper.AddressLine2);
        EnterText(CertificateAddresLine3, EPAODataHelper.AddressLine3);
        EnterText(CertificateCity, EPAODataHelper.TownName);
        EnterText(CertificatePostcode, EPAODataHelper.PostCode);
        return this;
    }

    public CheckAndSubmitAssessmentDetailsPage EnterReasonForChangeAndContinue(string reasonForChange)
    {
        EnterText(CertificateReasonForChange, reasonForChange);
        Continue();
        return new CheckAndSubmitAssessmentDetailsPage(context);
    }

    private void EnterText(By locator, string text) { if (!(string.IsNullOrEmpty(text))) formCompletionHelper.EnterText(locator, text); }
}